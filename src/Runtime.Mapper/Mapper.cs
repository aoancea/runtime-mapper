using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Runtime.Mapper
{
    public static class Mapper
    {
        private static HashSet<Type> primitiveTypes = new HashSet<Type>(new List<Type>()
        {
            typeof(int),    typeof(decimal),    typeof(string),     typeof(Guid),   typeof(DateTime),   typeof(Enum),   typeof(bool),   typeof(char),
            typeof(int?),   typeof(decimal?),                       typeof(Guid?),  typeof(DateTime?),                  typeof(bool?),  typeof(char?)
        });

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
            Type sourceType = source.GetType();
            Type destinationType = typeof(TDestination);

            Tuple<Type, Type> key = new Tuple<Type, Type>(sourceType, destinationType);

            Func<object, object, object> mappingFunction = mappingFunctions.GetOrAdd(key, GetMappingFunction(sourceType, destinationType));

            mappingFunction(source, destination);
        }


        private static Func<object, object, object> GetMappingFunction(Type sourceType, Type destinationType)
        {
            ParameterExpression sourceParam = Expression.Parameter(typeof(object), "sourceObj");
            ParameterExpression destinationParam = Expression.Parameter(typeof(object), "destinationObj");

            List<Expression> expressions = new List<Expression>();

            ParameterExpression sourceVar = Expression.Variable(sourceType, "source");
            ParameterExpression destinationVar = Expression.Variable(destinationType, "destination");

            expressions.Add(Expression.Assign(sourceVar, Expression.Convert(sourceParam, sourceType)));
            expressions.Add(Expression.Assign(destinationVar, Expression.Convert(Expression.Constant(null), destinationType)));

            expressions.AddRange(MapObjectExpression(sourceType, destinationType, sourceVar, destinationVar, destinationParam, true));

            expressions.Add(destinationVar);

            LambdaExpression mappingFunctionLambda = Expression.Lambda(Expression.Block(new ParameterExpression[] { sourceVar, destinationVar }, expressions), new ParameterExpression[] { sourceParam, destinationParam });

            return (Func<object, object, object>)mappingFunctionLambda.Compile();
        }

        private static List<Expression> MapObjectExpression(Type sourceType, Type destinationType, Expression sourceVar, Expression destinationVar, Expression destinationParam, bool isRoot)
        {
            List<Expression> expressions = new List<Expression>();

            if (sourceType.IsArray || destinationType.IsArray || IsGenericList(sourceType) || IsGenericList(destinationType))
            {
                // map array or list

                Expression sourceLength = Expression.Property(sourceVar, sourceType.IsArray ? "Length" : "Count");
                ParameterExpression collectionLength = Expression.Parameter(typeof(int), "collectionLength");

                ParameterExpression index = Expression.Parameter(typeof(int), "i");
                LabelTarget label = Expression.Label(typeof(void));

                Expression initDestination = null;
                Expression loopContent = null;

                Expression sourceAccessor = null;

                if (destinationType.IsArray)
                {
                    Type underlyingType = destinationType.GetElementType();

                    MethodInfo miDeepCopyTo = typeof(Mapper).GetMethod("DeepCopyTo", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(underlyingType);

                    initDestination = Expression.Assign(destinationVar, Expression.NewArrayBounds(underlyingType, sourceLength));

                    sourceAccessor = Expression.ArrayIndex(sourceVar, index);

                    if (!primitiveTypes.Contains(underlyingType))
                    {
                        sourceAccessor = Expression.Call(miDeepCopyTo, sourceAccessor);
                    }

                    loopContent = Expression.Assign(Expression.ArrayAccess(destinationVar, index), sourceAccessor);
                }
                else
                {
                    Type underlyingType = destinationType.GetGenericArguments()[0];

                    MethodInfo miDeepCopyTo = typeof(Mapper).GetMethod("DeepCopyTo", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(underlyingType);

                    initDestination = Expression.Assign(destinationVar, Expression.New(destinationType.GetConstructor(new Type[] { typeof(int) }), new Expression[] { sourceLength }));

                    sourceAccessor = Expression.MakeIndex(sourceVar, destinationType.GetProperty("Item"), new Expression[] { index });

                    if (!primitiveTypes.Contains(underlyingType))
                    {
                        sourceAccessor = Expression.Call(miDeepCopyTo, sourceAccessor);
                    }

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
                // map dictionary
            }
            else if (primitiveTypes.Contains(sourceType))
            {
                // map primitive type => this should not be the case for now :)

                expressions.Add(Expression.Assign(destinationVar, sourceVar));
            }
            else
            {
                // map object's properties

                if (isRoot)
                {
                    Expression assignDestinationExpresion = Expression.IfThenElse(Expression.Equal(destinationParam, Expression.Constant(null)),
                        Expression.Assign(destinationVar, Expression.New(destinationType)),
                        Expression.Assign(destinationVar, Expression.Convert(destinationParam, destinationType)));

                    expressions.Add(assignDestinationExpresion);
                    expressions.AddRange(MapPropertiesExpression(sourceType, destinationType, sourceVar, destinationVar));
                }
                else
                {
                    MethodInfo miDeepCopyTo = typeof(Mapper).GetMethod("DeepCopyTo", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(destinationType);

                    expressions.Add(Expression.Assign(destinationVar, Expression.Call(miDeepCopyTo, sourceVar)));
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

                expressions.AddRange(MapObjectExpression(sourcePropType, destinationPropType, sourcePropertyAccessor, destinationPropertyAccessor, destinationPropertyAccessor, false));
            }

            return expressions;
        }

        private static bool IsGenericList(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        private static bool IsGenericDictionary(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }
    }
}