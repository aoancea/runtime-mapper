using System;
using System.Collections.Generic;

namespace Runtime.Mapper
{
    public static class Mapper
    {
        private static Dictionary<Tuple<Type, Type>, Func<object, object, object>> mappingFunctions = new Dictionary<Tuple<Type, Type>, Func<object, object, object>>();

        public static TDestination DeepCopyTo<TDestination>(this object source)
        {
            return default(TDestination);
        }

        public static void Map<TSource, TDestination>(TSource source, TDestination destination)
        {

        }
    }
}