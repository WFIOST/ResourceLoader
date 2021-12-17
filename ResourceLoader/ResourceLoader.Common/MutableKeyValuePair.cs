using System.Collections.Generic;
namespace ResourceLoader.Common
{
    public struct MutableKeyValuePair<TKey, TValue>
    {
        public TKey     Key     { get; set; }
        public TValue   Value   { get; set; }

        public KeyValuePair<TKey, TValue> AsImmutable => new KeyValuePair<TKey, TValue>(Key, Value);
    }
}