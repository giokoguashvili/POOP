using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Infrastructure
{
    public class Curried<T1, T2, TLast, TResult>
    {
        private readonly Func<T1, T2, TLast, TResult> _func;
        public Curried(Func<T1, T2, TLast, TResult> func)
        {
            _func = func;
        }

        public Invocable<TLast, TResult> Curry(T2 param2)
        {
            return new Invocable<TLast, TResult>((lastParam) => _funcs());
        }
    }


    public class Curried<T1, TLast, TResult>
	{
        private readonly Func<T1, TLast, TResult> _func;
        public Curried(Func<T1, TLast, TResult> func)
        {
            _func = func;
        }

        public Invocable<TLast, TResult> Curry(T1 par1)
        {
            return new Invocable<TLast, TResult>((lastParam) => _func(par1, lastParam));
        }
    }

    public class Invocable<TLast, TResult>
    {
        private readonly Func<TLast, TResult> _func;
        public Invocable(Func<TLast, TResult> func)
        {
            _func = func;
        }

        public TResult Invoke(TLast lastParam)
        {
            return _func(lastParam);
        }
    }
}
