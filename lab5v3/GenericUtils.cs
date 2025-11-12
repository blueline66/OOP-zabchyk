using System;
using System.Collections.Generic;

namespace Lab5v3.Utils
{
    public static class GenericUtils
    {
        public static T Max<T>(IEnumerable<T> items, IComparer<T> comparer)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            using var e = items.GetEnumerator();
            if (!e.MoveNext()) throw new InvalidOperationException("Послідовність порожня.");

            var max = e.Current;
            while (e.MoveNext())
                if (comparer.Compare(e.Current, max) > 0)
                    max = e.Current;

            return max;
        }
    }
}
