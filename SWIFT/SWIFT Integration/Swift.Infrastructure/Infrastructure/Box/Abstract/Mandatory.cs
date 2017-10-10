using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure.Box.Abstract
{
    public abstract class Mandatory<T> : IMandatory<T>
    {
        public abstract IMandatory<T> Content();

        public T Fold()
        {
            return Content().First();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Content().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}