using System;
using System.Collections;
using System.Collections.Generic;

namespace Swift.Infrastructure.Infrastructure.Iterable
{
    public abstract class Iterable<T> : IEnumerable<T>
    {
        public abstract IIterable<T> Items();
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}