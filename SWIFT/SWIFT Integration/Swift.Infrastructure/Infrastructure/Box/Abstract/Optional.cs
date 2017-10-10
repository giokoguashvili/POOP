using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure.Box.Abstract
{
    public abstract class Optional<T> : IOptional<T>
    {

        public abstract IOptional<T> Content();

        public virtual T Fold(T defaultValue)
        {
            if (Content().Any())
            {
                return Content().First();
            }
            return defaultValue;
        }

        public TResult Fold<TResult>(Func<T, TResult> some, Func<string, TResult> nothing)
        {
            return Content().Fold(some, nothing);
        }

        public IMandatory<TResult> Match<TResult>(Func<T, TResult> some, Func<string, TResult> nothing)
        {
            return Content().Match(
                some: some,
                nothing: nothing
            );
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