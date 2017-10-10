using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure.Box.Concrete
{
    public class Option<T> : IOptional<T>
    {
        private readonly IEnumerable<T> _data;
        private readonly string _error;

        public Option(bool condition, Func<T> action)
            :this(condition ? new [] {action()} : new T[0])
        {}
        public Option(T opt, Func<T, bool> pred)
            : this(opt, pred(opt))
        { }

        public Option(T opt, bool condition)
            : this(condition ? new [] { opt } : new T[0])
        { }
        public Option(IOptional<T> opt, bool condition)
            :this(condition ? (IEnumerable<T>)opt : new T[0])
        {}

        public Option(IOptional<T> opt)
            : this((IEnumerable<T>)opt)
        {}
        public Option(T element)
            : this(element == null ? new T[0] : new [] { element })
        { }

        public Option(string errorMessage = "")
            : this(new T[0], errorMessage)
        {
        }

        public Option(IEnumerable<T> data, string error = "")
        {
            _data = data;
            _error = error;
        }

        public T Fold(T defaultValue)
        {
            if (_data.Any())
            {
                return _data.First();
            }
            return defaultValue;
        }

        public TResult Fold<TResult>(Func<T, TResult> some, Func<string, TResult> nothing)
        {
            if (_data.Any())
            {
                return some(_data.First());
            }
            else
            {
                return nothing(_error);
            }
        }

        public IMandatory<TResult> Match<TResult>(
                Func<T, TResult> some,
                Func<string, TResult> nothing
            )
        {
            return new Mandator<TResult>(Fold(some, nothing));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}