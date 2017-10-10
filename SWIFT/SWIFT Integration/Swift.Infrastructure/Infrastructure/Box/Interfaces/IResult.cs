using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Infrastructure.Infrastructure.Box.Interfaces
{
    public interface IResult<TSomething, out TError> : IOptional<TSomething>
    {
        IMandatory<TError> Error();
        IMandatory<TResult> Error<TResult>(Func<TError, TResult> func);
    }

    public class Result
}
