using System.Collections.Generic;

namespace Extensions.Web.Core.Extensions
{
    public static class ICollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> target, ICollection<T> source)
        {
            foreach (var item in source)
            {
                target.Add(item);
            }
        }
    }
}
