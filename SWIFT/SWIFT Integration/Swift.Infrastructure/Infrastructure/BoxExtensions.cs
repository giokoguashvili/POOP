using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure
{
    public static class BoxExtensions
    {
        public static IForked<T> Fork<T, TResult>(this IEnumerable<IOptional<T>> src, Func<T, TResult> somes, Func<string, TResult> notings)
        {
            return new Forked<T>(src);
        }
    }

    public interface IForked<out T> 
    {
        IEnumerable<T> Somethings();
        IEnumerable<string> Nothings();
    }

    public class Forked<T> : IForked<T>
    {
        private readonly IEnumerable<IOptional<T>> _src;

        public Forked(IEnumerable<IOptional<T>> src)
        {
            _src = src;
        }
        public IEnumerable<T> Somethings()
        {
            return _src.SelectMany(s => s);
        }

        public IEnumerable<string> Nothings()
        {
            return _src
                .Where(mtr => mtr.Fold(some: rule => false, nothing: m => true))
                .SelectMany(mtr => mtr.Match(some: (a) => "", nothing: (m) => m));
        }
    }
}
