using System;
using System.Collections;
using System.Collections.Generic;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure.Box.Concrete
{
    public class LazyMandator<T> : IMandatory<T>
    {
        private readonly Func<T> _func;

        public LazyMandator(Func<T> func)
        {
            _func = func;
        }
        public T Fold()
        {
            return new Mandator<T>(_func()).Fold();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Mandator<T>(_func()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
