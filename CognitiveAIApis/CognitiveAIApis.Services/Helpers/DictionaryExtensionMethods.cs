using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CognitiveAIApis.Services.Helpers
{
    public static class DictionaryExtensionMethods
    {
        public static Dictionary<TKey, TValue> ExtendWith<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> keyValuePair)
        {
            return source.Append(keyValuePair).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public static Dictionary<TKey, TValue> ExtendWith<TKey, TValue>(this Dictionary<TKey, TValue> source, Dictionary<TKey, TValue> keyValuesDict)
        {
            return source.Concat(keyValuesDict).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public static Dictionary<TKey, TValue> with<TKey, TValue>(this Dictionary<TKey, TValue> keyValueDict, TKey key, TValue value)
        {
            return keyValueDict.ExtendWith(new KeyValuePair<TKey, TValue>(key, value));
        }

        public static Dictionary<TKey, TValue> InitializeIfNull<TKey, TValue>(this Dictionary<TKey, TValue> source)
        {
            return  (source = source ?? new Dictionary<TKey, TValue>());
        }
    }
}
