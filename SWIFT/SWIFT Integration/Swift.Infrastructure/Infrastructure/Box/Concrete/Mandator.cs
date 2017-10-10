using System.Collections;
using System.Collections.Generic;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure.Box.Concrete
{
    public class Mandator<T> : IMandatory<T>
    {
        private readonly T _data;
        public Mandator(T data)
        {
            _data = data;
        }
        public T Fold()
        {
            return _data;
        }
        public IEnumerator<T> GetEnumerator()
        {
            yield return _data;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}