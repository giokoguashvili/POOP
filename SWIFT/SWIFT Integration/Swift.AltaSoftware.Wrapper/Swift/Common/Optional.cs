using System;
using System.Linq;

namespace Swift.AltaSoftware.Wrapper.Swift.Common
{
    public class NullIfEmpty<T> where T: class
    {
        private readonly string[] _strs;
        private readonly Func<string, T> _func;

        public NullIfEmpty(bool condition, T obj) 
            : this(condition ? "something" : String.Empty, str => obj)
        {}
        public NullIfEmpty(string str, Func<string, T> func)
            : this(new [] { str}, func)
        {
            _func = func;
        }
        public NullIfEmpty(Func<T> func, params string[] par)
            : this(par, (strs) => func())
        {
            
        }

        public NullIfEmpty(string[] strs, Func<string, T> func)
        {
            _strs = strs;
            _func = func;
        }

        public T Value()
        {
            return _strs.All(String.IsNullOrEmpty) ? null : _func(_strs.First());
        }
    }
}