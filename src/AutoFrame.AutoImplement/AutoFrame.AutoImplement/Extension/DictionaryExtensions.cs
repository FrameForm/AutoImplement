using System.Collections.Generic;

namespace AutoFrame.AutoImplement.Extension
{
    public static class DictionaryExtensions
    {
        public static void CheckedAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value, object lockObj)
        {
            if (!dict.ContainsKey(key))
            {
                lock (lockObj)
                {
                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, value);
                    }
                }
            }
        }

        public static void CheckedAddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value,
            object lockObj)
        {
            lock (lockObj)
            {
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, value);
                }
                else
                {
                    dict[key] = value;
                }
            }
        }

    }
}
