using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure.Box.Abstract;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure.Box
{
    public class FirstOptional<T> : Optional<T>
    {
        private readonly IOptional<T> _option;
        public FirstOptional(IOptional<T> first, IOptional<T> second)
        {
            _option = new Option<T>(
                            new List<IOptional<T>>() { first, second }
                                .FirstOrDefault(o => o.Any())
                        );
        }

        public override IOptional<T> Content()
        {
            return _option;
        }
    }
}