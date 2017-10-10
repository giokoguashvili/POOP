using System.Collections.Generic;

namespace Swift.Infrastructure.Infrastructure.Box.Interfaces
{
    public interface IBox<out T> : IEnumerable<T>
    {
    }
}
