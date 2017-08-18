using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Infrastructure
{
    public static class Extensions
    {
        public static Curried1<T1, T2, TLast, TResult> Curried<T1, T2, TLast, TResult>(Func<T1, T2, TLast, TResult> func)
        {
            return new Curried1<T1, T2, TLast, TResult>(func);
        }
    }
    public class Curried1<T1, T2, TLast, TResult>
    {
        private readonly Func<T1, T2, TLast, TResult> _func;
        public Curried1(Func<T1, T2, TLast, TResult> func)
        {
            _func = func;
        }

        public Curried<T2, TLast, TResult> Curry(T1 param1)
        {
            return new Curried<T2, TLast, TResult>((param2, lastParam) => _func(param1, param2, lastParam));
        }
        public Invocable<TLast, TResult> Curry(T1 param1, T2 param2)
        {
            return new Invocable<TLast, TResult>((lastParam) => _func(param1, param2, lastParam));
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

        public TResult Invoke(T1 param1, TLast lastParam)
        {
            return _func(param1, lastParam);
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

    public class Bar { }

    public class Foo<T>
    {
        public Foo(T data) {}
    }

    class MyClass
    {
        public MyClass()
        {

        }
    }
}
