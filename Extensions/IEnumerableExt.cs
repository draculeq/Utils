using System;
using System.Collections.Generic;
using System.Linq;

namespace Deadbit.Utils.Extensions
{
    public static class IEnumerableExt
    {
        public static T Random<T>(this IEnumerable<T> me)
        {
            var enumerable = me as IList<T> ?? me.ToList();
            return enumerable.ElementAt(UnityEngine.Random.Range(0, enumerable.Count()));
        }
    }
}
