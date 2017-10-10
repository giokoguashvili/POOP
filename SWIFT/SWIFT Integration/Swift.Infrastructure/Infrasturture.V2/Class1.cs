using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Infrastructure.Infrasturture.V2
{
    public interface IThing<out T> : IEnumerable<T> { }
    public class Thing<T> : IThing<T>
    {
        private readonly T _thing;

        public Thing(T thing)
        {
            _thing = thing;
        }
        public IEnumerator<T> GetEnumerator()
        {
            yield return _thing;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public interface INothing<out T> : IThing<T> {}

    public interface ISomething<out TThing, out TNothing> : IThing<TThing>
    {
        IThing<TThing> Thing();
        INothing<TNothing> Nothing();
    }

    public class Something<TThing, TNothing> : ISomething<TThing, TNothing>
    {
        public IThing<TThing> Thing()
        {
            throw new NotImplementedException();
        }

        public INothing<TNothing> Nothing()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TThing> GetEnumerator()
        {
            return Thing().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Nothing
    {
        
    }
}
