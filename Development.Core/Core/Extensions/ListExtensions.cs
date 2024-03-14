using System;
using System.Collections.Generic;

namespace Extensions.Web.Core.Extensions
{
    public static class ListExtensions
    {
        public static IEnumerable<(int Position, List<T> Items)> GetChunk<T>(this List<T> collection, int chunkSize)
        {
            var index = 0;

            while (index < collection.Count)
            {
                var range = collection.Count - index >= chunkSize ? chunkSize : (collection.Count - index) % chunkSize;
                var chunk = collection.GetRange(index, range);

                yield return (index, chunk);

                index += range;
            }
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
