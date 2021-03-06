﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Runtime.Mapper
{
    public static class Mapper
    {
        private static ConcurrentDictionary<Tuple<Type, Type>, Func<object, object, object>> mappingFunctions = new ConcurrentDictionary<Tuple<Type, Type>, Func<object, object, object>>();

        public static TDestination DeepCopyTo<TDestination>(this object source)
        {
            if (source == null)
                return default(TDestination);

            Type sourceType = source.GetType();
            Type destinationType = typeof(TDestination);

            Tuple<Type, Type> key = new Tuple<Type, Type>(sourceType, destinationType);

            Func<object, object, object> mappingFunction = mappingFunctions.GetOrAdd(key, GetMappingFunction(sourceType, destinationType));

            return (TDestination)mappingFunction(source, null);
        }

        public static void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            if (source == null)
                return;

            Type sourceType = source.GetType();
            Type destinationType = typeof(TDestination);

            Tuple<Type, Type> key = new Tuple<Type, Type>(sourceType, destinationType);

            Func<object, object, object> mappingFunction = mappingFunctions.GetOrAdd(key, GetMappingFunction(sourceType, destinationType));

            mappingFunction(source, destination);
        }


        private static Func<object, object, object> GetMappingFunction(Type sourceType, Type destinationType)
        {
            if (sourceType != destinationType)
            {
                if (destinationType == typeof(object))
                    destinationType = sourceType;

                if ((destinationType.IsInterface || destinationType.IsAbstract) && destinationType.IsAssignableFrom(sourceType))
                    destinationType = sourceType;
            }

            ParameterExpression sourceParam = Expression.Parameter(typeof(object), "sourceObj");
            ParameterExpression destinationParam = Expression.Parameter(typeof(object), "destinationObj");

            List<Expression> expressions = new List<Expression>();

            ParameterExpression sourceVar = Expression.Variable(sourceType, "source");
            ParameterExpression destinationVar = Expression.Variable(destinationType, "destination");

            expressions.Add(Expression.Assign(sourceVar, Expression.Convert(sourceParam, sourceType)));

            if (!destinationType.IsValueType)
                expressions.Add(Expression.Assign(destinationVar, Expression.Convert(Expression.Constant(null), destinationType)));

            expressions.AddRange(MapObjectExpression(sourceType, destinationType, sourceVar, destinationVar, destinationParam, false));

            if (destinationType.IsValueType)
                expressions.Add(Expression.Convert(destinationVar, typeof(object)));
            else
                expressions.Add(destinationVar);

            LambdaExpression mappingFunctionLambda = Expression.Lambda(Expression.Block(new ParameterExpression[] { sourceVar, destinationVar }, expressions), new ParameterExpression[] { sourceParam, destinationParam });

            return (Func<object, object, object>)mappingFunctionLambda.Compile();
        }

        private static List<Expression> MapObjectExpression(Type sourceType, Type destinationType, Expression sourceVar, Expression destinationVar, Expression destinationParam, bool deepCopyCustomTypes)
        {
            List<Expression> expressions = new List<Expression>();

            if (sourceType.IsArray || destinationType.IsArray || IsGenericList(sourceType) || IsGenericList(destinationType))
            {
                Type destinationUnderlyingType = ArrayOrListUnderlyingType(destinationType);

                Expression sourceLength = Expression.Property(sourceVar, sourceType.IsArray ? "Length" : "Count");
                ParameterExpression collectionLength = Expression.Parameter(typeof(int), "collectionLength");

                ParameterExpression index = Expression.Parameter(typeof(int), "i");
                LabelTarget label = Expression.Label(typeof(void));

                Expression initDestination = null;
                Expression loopContent = null;

                Expression sourceAccessor = null;

                if (sourceType.IsArray)
                {
                    sourceAccessor = Expression.ArrayIndex(sourceVar, index);
                }
                else
                {
                    sourceAccessor = Expression.MakeIndex(sourceVar, sourceType.GetProperty("Item"), new Expression[] { index });
                }

                if (destinationUnderlyingType.IsEnum || (destinationUnderlyingType.IsGenericType && destinationUnderlyingType.GetGenericTypeDefinition() == typeof(Nullable<>) && destinationUnderlyingType.GetGenericArguments()[0].IsEnum))
                {
                    sourceAccessor = Expression.Convert(sourceAccessor, destinationUnderlyingType);
                }
                else if (!destinationUnderlyingType.IsValueType)
                {
                    MethodInfo miDeepCopyTo = typeof(Mapper).GetMethod("DeepCopyTo", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(destinationUnderlyingType);

                    sourceAccessor = Expression.Call(miDeepCopyTo, sourceAccessor);
                }

                if (destinationType.IsArray)
                {
                    initDestination = Expression.Assign(destinationVar, Expression.NewArrayBounds(destinationUnderlyingType, sourceLength));

                    loopContent = Expression.Assign(Expression.ArrayAccess(destinationVar, index), sourceAccessor);
                }
                else
                {
                    initDestination = Expression.Assign(destinationVar, Expression.New(destinationType.GetConstructor(new Type[] { typeof(int) }), new Expression[] { sourceLength }));

                    loopContent = Expression.Call(destinationVar, destinationType.GetMethod("Add", new Type[] { destinationType.GetGenericArguments()[0] }), sourceAccessor);
                }

                Expression loopCondition = Expression.LessThan(index, sourceLength);

                Expression increment = Expression.PostIncrementAssign(index);

                Expression loopBlock = Expression.Block(new[] { collectionLength, index },
                    Expression.Assign(collectionLength, sourceLength),
                    Expression.Assign(index, Expression.Constant(0)),
                    Expression.Loop(
                        Expression.IfThenElse(
                            loopCondition,
                                Expression.Block(loopContent, increment),
                                Expression.Break(label)),
                        label)
                );

                Expression checkNullCollection = Expression.IfThenElse(Expression.NotEqual(sourceVar, Expression.Constant(null)),
                    Expression.Block(initDestination, loopBlock),
                    Expression.Empty());

                expressions.Add(checkNullCollection);
            }
            else if (IsGenericDictionary(sourceType) || IsGenericDictionary(destinationType))
            {
                Type sourceKeyUnderlyingType = sourceType.GetGenericArguments()[0];
                Type sourceValueUnderlyingType = sourceType.GetGenericArguments()[1];

                Type destinationKeyUnderlyingType = destinationType.GetGenericArguments()[0];
                Type destinationValueUnderlyingType = destinationType.GetGenericArguments()[1];

                Expression initDestination = Expression.Assign(destinationVar, Expression.New(typeof(Dictionary<,>).MakeGenericType(destinationKeyUnderlyingType, destinationValueUnderlyingType)));

                Type elementType = typeof(KeyValuePair<,>).MakeGenericType(sourceKeyUnderlyingType, sourceValueUnderlyingType);
                Type enumerableType = typeof(IEnumerable<>).MakeGenericType(elementType);
                Type enumeratorType = typeof(IEnumerator<>).MakeGenericType(elementType);

                ParameterExpression enumeratorVar = Expression.Variable(enumeratorType, "enumerator");
                Expression enumeratorCurrent = Expression.Property(enumeratorVar, "Current");

                Expression getEnumeratorCall = Expression.Call(sourceVar, enumerableType.GetMethod("GetEnumerator"));
                Expression enumeratorAssign = Expression.Assign(enumeratorVar, getEnumeratorCall);

                Expression sourceKeyAccessor = Expression.Property(enumeratorCurrent, "Key");
                Expression sourceValueAccessor = Expression.Property(enumeratorCurrent, "Value");

                if (!destinationKeyUnderlyingType.IsValueType)
                {
                    MethodInfo miDeepCopyTo = typeof(Mapper).GetMethod("DeepCopyTo", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(destinationKeyUnderlyingType);

                    sourceKeyAccessor = Expression.Call(miDeepCopyTo, sourceKeyAccessor);
                }

                if (!destinationValueUnderlyingType.IsValueType)
                {
                    MethodInfo miDeepCopyTo = typeof(Mapper).GetMethod("DeepCopyTo", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(destinationValueUnderlyingType);

                    sourceValueAccessor = Expression.Call(miDeepCopyTo, sourceValueAccessor);
                }

                Expression loopContent = Expression.Call(destinationVar, destinationType.GetMethod("Add", new Type[] { destinationKeyUnderlyingType, destinationValueUnderlyingType }), sourceKeyAccessor, sourceValueAccessor);

                Expression moveNextCall = Expression.Call(enumeratorVar, typeof(IEnumerator).GetMethod("MoveNext"));

                LabelTarget breakLabel = Expression.Label("LoopBreak");

                Expression loopBlock = Expression.Block(new[] { enumeratorVar },
                    Expression.Assign(enumeratorVar, getEnumeratorCall),
                    Expression.Loop(
                        Expression.IfThenElse(
                            Expression.Equal(moveNextCall, Expression.Constant(true)),
                                Expression.Block(new[] { loopContent }),
                                Expression.Break(breakLabel)
                        ),
                    breakLabel)
                );

                Expression checkNullCollection = Expression.IfThenElse(Expression.NotEqual(sourceVar, Expression.Constant(null)),
                    Expression.Block(initDestination, loopBlock),
                    Expression.Empty());

                expressions.Add(checkNullCollection);
            }
            else if (sourceType == typeof(string) || destinationType == typeof(string))
            {
                expressions.Add(MapStringExpression(sourceType, destinationType, sourceVar, destinationVar));
            }
            else if (sourceType.IsValueType || destinationType.IsValueType)
            {
                expressions.Add(MapValueTypeExpression(sourceType, destinationType, sourceVar, destinationVar));
            }
            else
            {
                if (deepCopyCustomTypes)
                {
                    MethodInfo miDeepCopyTo = typeof(Mapper).GetMethod("DeepCopyTo", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(destinationType);

                    expressions.Add(Expression.Assign(destinationVar, Expression.Call(miDeepCopyTo, sourceVar)));
                }
                else
                {
                    Expression assignDestinationExpresion = Expression.IfThenElse(Expression.Equal(destinationParam, Expression.Constant(null)),
                        Expression.Assign(destinationVar, Expression.New(destinationType)),
                        Expression.Assign(destinationVar, Expression.Convert(destinationParam, destinationType)));

                    expressions.Add(assignDestinationExpresion);
                    expressions.AddRange(MapPropertiesExpression(sourceType, destinationType, sourceVar, destinationVar));
                }
            }

            return expressions;
        }


        private static List<Expression> MapPropertiesExpression(Type sourceType, Type destinationType, Expression sourceVar, Expression destinationVar)
        {
            List<Expression> expressions = new List<Expression>();

            PropertyInfo[] sourceProperties = sourceType.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToArray();
            PropertyInfo[] destinationProperties = destinationType.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToArray();

            PropertyInfo[] properties = destinationProperties.Where(dp => sourceProperties.Any(sp => sp.Name == dp.Name)).ToArray();

            foreach (PropertyInfo property in properties)
            {
                Type sourcePropType = sourceProperties.First(x => x.Name == property.Name).PropertyType;
                Type destinationPropType = destinationProperties.First(x => x.Name == property.Name).PropertyType;

                MemberExpression sourcePropertyAccessor = Expression.Property(sourceVar, property.Name);
                MemberExpression destinationPropertyAccessor = Expression.Property(destinationVar, property.Name);

                expressions.AddRange(MapObjectExpression(sourcePropType, destinationPropType, sourcePropertyAccessor, destinationPropertyAccessor, destinationPropertyAccessor, true));
            }

            return expressions;
        }

        private static Expression MapStringExpression(Type sourceType, Type destinationType, Expression sourceVar, Expression destinationVar)
        {
            if (sourceType == destinationType)
                return Expression.Assign(destinationVar, sourceVar);

            return Expression.Empty();
        }

        private static Expression MapValueTypeExpression(Type sourceType, Type destinationType, Expression sourceVar, Expression destinationVar)
        {
            Type underlyingSourceType = NullableUnderlyingType(sourceType);
            Type underlyingDestinationType = NullableUnderlyingType(destinationType);

            bool ofSameUnderlyingType = underlyingSourceType == underlyingDestinationType;
            bool bothAreEnums = underlyingSourceType.IsEnum && underlyingDestinationType.IsEnum;

            if (ofSameUnderlyingType || bothAreEnums)
            {
                Expression assignmentExpression = AssignOrConvertAndAssignExpression(sourceType, destinationType, sourceVar, destinationVar);

                if (IsNullableType(sourceType))
                {
                    Expression checkNullAssignmentExpression = Expression.IfThenElse(
                        Expression.Equal(Expression.Property(sourceVar, "HasValue"), Expression.Constant(true)),
                            assignmentExpression,
                            Expression.Assign(destinationVar, Expression.Default(destinationType)));

                    return checkNullAssignmentExpression;
                }

                return assignmentExpression;
            }

            return Expression.Empty();
        }

        private static bool IsGenericList(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        private static bool IsGenericDictionary(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static Expression AssignOrConvertAndAssignExpression(Type sourceType, Type destinationType, Expression sourceVar, Expression destinationVar)
        {
            if (sourceType == destinationType)
                return Expression.Assign(destinationVar, sourceVar);
            else
                return Expression.Assign(destinationVar, Expression.Convert(sourceVar, destinationType));
        }

        private static Type NullableUnderlyingType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                type.GetGenericArguments()[0]
                :
                type;
        }

        private static Type ArrayOrListUnderlyingType(Type type)
        {
            return type.IsArray ?
                type.GetElementType()
                :
                type.GetGenericArguments()[0];
        }
    }
}
