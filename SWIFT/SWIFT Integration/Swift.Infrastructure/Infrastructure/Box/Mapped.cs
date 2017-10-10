using System;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure.Box.Abstract;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure.Box
{
    public class Mapped<TInput, TResult> : Optional<TResult>
    {
        private readonly IOptional<TInput> _first;
        private readonly Func<IMandatory<TInput>, TResult> _func;

        public Mapped(IEnumerable<TInput> elems, Func<IMandatory<TInput>, TResult> func) 
            : this(elems.Any() ? new Option<TInput>(elems.First()) : new Option<TInput>(), func)
        {
            
        }
        public Mapped(IOptional<TInput> first, Func<IMandatory<TInput>, TResult> func)
        {
            _first = first;
            _func = func;
        }
        public override IOptional<TResult> Content()
        {
            if (_first.Any())
            {
                return new Option<TResult>(
                    _func(new Mandator<TInput>(_first.First()))
                );
            }
            else
            {
                return new Option<TResult>();
            }
        }
    }
}