using System.Collections;
using System.Collections.Generic;

namespace Swift.Infrastructure.Infrastructure.Iterable
{
    public class Collection<T> : IIterable<T>
    {
        private readonly IEnumerable<T> _array;

        public Collection(T item1)
            : this(new [] { item1 })
        {}

        public Collection(T item1, T item2)
            : this(new[] { item1, item2 })
        { }

        public Collection(T item1, T item2, T item3)
            : this(new[] { item1, item2, item3 })
        { }

        public Collection(T item1, T item2, T item3, T item4)
            : this(new[] { item1, item2, item3, item4 })
        { }
        public Collection(IEnumerable<T> array)
        {
            _array = array;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}