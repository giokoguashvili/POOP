using System;
using System.Linq;
using Swift.Infrastructure.Infrastructure.Box.Abstract;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure
{
    public class Join<T> : Optional<T>
    {
        private readonly IOptional<T> _first;
        private readonly IOptional<T> _second;
        private readonly Func<T, T, T> _func;

        public Join(IOptional<T> first, IOptional<T> second, Func<T, T, T> func)
        {
            _first = first;
            _second = second;
            _func = func;
        }

        public override IOptional<T> Content()
        {
            return _first
                .SelectMany(f => _second.Select(s => _func(f, s)))
                .Select(i => new Option<T>(i))
                .First();
        }
    }
}