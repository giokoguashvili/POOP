using System;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure.Box.Abstract;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure.Box
{
    public class Filtered<TInput> : Optional<TInput>
    {
        private readonly IOptional<TInput> _first;
        private readonly Func<IMandatory<TInput>, bool> _func;

        public Filtered(IEnumerable<TInput> elems, Func<IMandatory<TInput>, bool> func) 
            : this(elems.Any() ? new Option<TInput>(elems.First()) : new Option<TInput>(), func)
        {

        }
        public Filtered(IOptional<TInput> first, Func<IMandatory<TInput>, bool> func)
        {
            _first = first;
            _func = func;
        }
        public override IOptional<TInput> Content()
        {
            if (_first.Any())
            {
                if (_func(new Mandator<TInput>(_first.First())))
                {
                    return new Option<TInput>(_first.First());
                }
                else
                {
                    return new Option<TInput>();
                }
            }
            else
            {
                return new Option<TInput>();
            }
        }
    }
}