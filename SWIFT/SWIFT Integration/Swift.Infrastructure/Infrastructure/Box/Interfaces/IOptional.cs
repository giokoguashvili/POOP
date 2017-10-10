using System;
using System.Collections.Generic;

namespace Swift.Infrastructure.Infrastructure.Box.Interfaces
{
    public interface IOptional<T> : IBox<T>
    {
        T Fold(T defaultValue);
        TResult Fold<TResult>(Func<T, TResult> some, Func<string, TResult> nothing);
        IMandatory<TResult> Match<TResult>(Func<T, TResult> some, Func<string, TResult> nothing);
    }



}
