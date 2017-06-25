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
        private static ConcurrentDictionary<Tuple<Type, Type>, Func<object, object, object>> mappingFunctions = new ConcurrentDictionary<Tuple<Type, Type>, Func<object, object, object>>();

        public static TDestination DeepCopyTo<TDestination>(this object source)
        {
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
            expressions.Add(Expression.Assign(destinationVar, Expression.Convert(Expression.Constant(null), sourceType)));

            Expression assignDestinationExpresion = Expression.IfThenElse(Expression.Equal(destinationParam, Expression.Constant(null)),
                Expression.Assign(destinationVar, Expression.New(destinationType)),
                Expression.Assign(destinationVar, Expression.Convert(destinationParam, destinationType)));

            expressions.Add(assignDestinationExpresion);

            expressions.Add(MapPropertiesExpression(sourceType, destinationType, sourceVar, destinationVar));

            expressions.Add(destinationVar);

            LambdaExpression mappingFunctionLambda = Expression.Lambda(Expression.Block(new ParameterExpression[] { sourceVar, destinationVar }, expressions), new ParameterExpression[] { sourceParam, destinationParam });

            return (Func<object, object, object>)mappingFunctionLambda.Compile();
        }


        private static Expression MapPropertiesExpression(Type sourceType, Type destinationType, ParameterExpression sourceVar, ParameterExpression destinationVar)
        {
            List<Expression> mapPropertyExpressions = new List<Expression>();

            PropertyInfo[] sourceProperties = sourceType.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToArray();
            PropertyInfo[] destinationProperties = destinationType.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToArray();

            string[] propertyNames = destinationProperties.Where(dp => sourceProperties.Any(sp => sp.Name == dp.Name)).Select(property => property.Name).ToArray();

            foreach (string propertyName in propertyNames)
            {
                MemberExpression sourcePropertyAccessorExpression = Expression.Property(sourceVar, propertyName);
                MemberExpression destinationPropertyAccessorExpression = Expression.Property(destinationVar, propertyName);

                mapPropertyExpressions.Add(Expression.Assign(destinationPropertyAccessorExpression, sourcePropertyAccessorExpression));
            }

            return Expression.Block(mapPropertyExpressions);
        }
    }
}