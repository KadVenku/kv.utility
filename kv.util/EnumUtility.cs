using System;
using System.Collections.Generic;
using System.Linq;

namespace kv.util
{
    public sealed class EnumUtility<T>
    {
        public static IEnumerable<T> GetValues()
        {
            IEnumerable<T> vals = Enum.GetValues(typeof(T)).Cast<T>();
            return vals;
        }
    }
}
