using System.Collections.Generic;

namespace Extensions.Web.Core.Extensions
{
    public static class DictionaryExtensions
    {
        public static T GetValueOrDefault<T, K>(this Dictionary<K, T> dictionary, K key)
        {
            if (dictionary == null || key == null)
            {
                return default;
            }

            return dictionary.TryGetValue(key, out var value) ? value : default;
        }
    }
}
