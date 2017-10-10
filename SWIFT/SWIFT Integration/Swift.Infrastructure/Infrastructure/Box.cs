using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Infrastructure.Infrastructure
{
    public class Box<T> : IContent<T>
    {
        private readonly T _element;

        public Box(T element)
        {
            _element = element;
        }
        public T Content()
        {
            return _element;
        }
    }
}
