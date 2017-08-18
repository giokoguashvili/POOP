using AggregatRoot.Infrastructure.DiscriminatedUnion;
using System;

namespace ConsoleApp1
{
    /// <summary>
    /// https://www.youtube.com/watch?v=uEHnI3pq_FM 
    /// I agree with that these two forms
    /// of decomposition are so exactly opposite, but 
    /// I don't agree with the conclusion!
    /// This is a property of programming language but not a FP or OOP paradigm.
    /// OOP is a continuation(or abstraction over) of FP
    /// 
    /// About Discriminated Unions:
    /// https://medium.com/@kogoia/discriminated-unions-for-designing-domain-models-in-c-1e54109adbdd
    /// </summary>
    /// <typeparam name="T1"></typeparam>

    //public interface IContain1<T1> { T1 Content(); }
    //public interface IContain2<T1, T2>
    //{
    //    T1 Content1();
    //    T2 Content2();
    //}
    //public interface IInt : IContain1<int> { }
    //public interface INegate : IContain1<Expr> { }
    //public interface IAdd : IContain2<Expr, Expr> { }

    public class Add
    {
        public Expr Left { get; }
        public Expr Right { get; }
        public Add(Expr left, Expr right)
        {
            Left = left;
            Right = right;
        }
    }

    public class Negate
    {
        public Expr Value { get; }
        public Expr Right { get; }
        public Negate(Expr expr)
        {
            Value = expr;
        }
    }

    public class Integer
    {
        public int Value;
        public Integer(int value)
        {
            Value = value;
        }
    }

    public class Expr : Union<Integer, Negate, Add>
    {
        public Expr(Integer t1) : base(t1)
        {
        }

        public Expr(Negate t2) : base(t2)
        {
        }

        public Expr(Add t3) : base(t3)
        {
        }
    }

    public interface IOOP
    {
        Expr add_values();
        Expr eval();
        bool hasZero();
        string toString();
    }

    public class OOP : IOOP
    {
        private readonly Expr _expr;
        public OOP(Expr expr)
        {
            _expr = expr;
        }

        public Expr add_values()
        {
            int Value(Expr a)
            {
                return a
                        .Match(
                            integer => integer.Value,
                            negate => throw new Exception("non-ints in addition"),
                            add1 => throw new Exception("non-ints in addition")
                        );
            }
            return _expr
                .Match(
                    integer => throw new Exception("non-ints in addition"),
                    negate => throw new Exception("non-ints in addition"),
                    add => new Expr(new Integer(Value(add.Left) + Value(add.Right)))
                );
        }

        public Expr eval()
        {
            return _expr
                .Match(
                    integer => _expr,
                    negate => new OOP(_expr).eval(),
                    add => new OOP(_expr).add_values()
                )
                .Match(
                    integer => new Expr(new Integer((-1) * integer.Value)),
                    negate => throw new Exception("non-ints in addition"),
                    add => throw new Exception("non-ints in addition")
                );
        }

        public string toString()
        {
            return _expr
               .Match(
                   integer => integer.Value.ToString(),
                   negate => "-(" + new OOP(_expr).toString() + ")",
                   add => "(" + new OOP(add.Left).toString() + " + " + new OOP(add.Right).toString() + ")"
               );
        }

        public bool hasZero()
        {
            return _expr
                .Match(
                    integer => integer.Value == 0,
                    negate => new OOP(_expr).hasZero(),
                    add => new OOP(add.Left).hasZero() || new OOP(add.Right).hasZero()
                );
        }
    }

    public class ExampleOfFP_OOP_Decomposition
    {
        public string Run()
        {
            return new OOP(
                        new Expr(
                            new Add(
                                new Expr(
                                    new Add(
                                        new Expr(new Integer(2)),
                                        new Expr(
                                            new Add(
                                                new Expr(new Integer(-8)),
                                                new Expr(new Integer(6))
                                            )
                                        )
                                    )
                                ),
                                new Expr(
                                    new Add(
                                       new Expr(new Integer(7)),
                                        new Expr(
                                            new Add(
                                                new Expr(new Integer(18)),
                                                new Expr(new Integer(63))
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    ).toString();
        }
    }
}

