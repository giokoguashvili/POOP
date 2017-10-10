using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Infrastructure.Infrastructure
{
    public abstract class AbstractDictionry<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public abstract IDictionary<TKey, TValue> Content();
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Content().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Content().Add(item);
        }

        public void Clear()
        {
            Content().Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Content().Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Content().CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Content().Remove(item);
        }

        public int Count => Content().Count;
        public bool IsReadOnly => Content().IsReadOnly;
        public bool ContainsKey(TKey key)
        {
            return Content().ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            Content().Add(key, value);
        }

        public bool Remove(TKey key)
        {
            return Content().Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return Content().TryGetValue(key, out value);
        }

        public TValue this[TKey key]
        {
            get => Content()[key];
            set => Content()[key] = value;
        }

        public ICollection<TKey> Keys => Content().Keys;
        public ICollection<TValue> Values => Content().Values;
    }
}
