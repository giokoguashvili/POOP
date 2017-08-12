using AggregatRoot.Infrastructure.DiscriminatedUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// https://www.youtube.com/watch?v=uEHnI3pq_FM 
    /// I do not agree with the conclusion!
    /// OOP is a continuation(/abstraction) of FP
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    public interface IContain1<T1> { T1 Content(); }
    public interface IContain2<T1, T2>
    {
        T1 Content1();
        T2 Content2();
    }
    public interface IInt : IContain1<int> { }
    public interface INegate : IContain1<Expr> { }
    public interface IAdd : IContain2<Expr, Expr> { }

    public class Add : IAdd
    {
        private readonly Expr _expr1;
        private readonly Expr _expr2;
        public Add(Expr expr1, Expr expr2)
        {
            _expr1 = expr1;
            _expr2 = expr2;
        }
        public Expr Content1()
        {
            return _expr1;
        }

        public Expr Content2()
        {
            return _expr2;
        }
    }

    public class Negate : INegate
    {
        public Expr Content()
        {
            throw new NotImplementedException();
        }
    }
    public class Integer : IInt
    {
        private readonly int _int;
        public Integer(int integer)
        {
            _int = integer;
        }
        public int Content()
        {
            return _int;
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

    public interface IFP_OOP_Decomposition
    {
        Expr add_values();
        Expr eval();
        string toString();
        bool hasZero();
    }

    public class FP_OOP_Decomposition : IFP_OOP_Decomposition
    {
        private readonly Expr _expr;
        public FP_OOP_Decomposition(Expr expr)
        {
            _expr = expr;
        }

        public Expr add_values()
        {
            return _expr
                .Match(
                    integer => throw new Exception("non-ints in addition"),
                    negate => throw new Exception("non-ints in addition"),
                    add => new Expr(
                                new Integer(
                                    add
                                        .Content1()
                                        .Match(
                                            integer => integer.Content(),
                                            negate => throw new Exception("non-ints in addition"),
                                            add1 => throw new Exception("non-ints in addition")
                                        )

                                        +
                                    add
                                        .Content2()
                                        .Match(
                                            integer => integer.Content(),
                                            negate => throw new Exception("non-ints in addition"),
                                            add1 => throw new Exception("non-ints in addition")
                                        )
                                )
                           )
                );
        }

        public Expr eval()
        {
            return _expr
                .Match(
                    integer => new Expr(integer),
                    negate => new FP_OOP_Decomposition(_expr).eval(),
                    add => new FP_OOP_Decomposition(_expr).add_values()
                )
                .Match(
                    integer => new Expr(new Integer(integer.Content() * (-1))),
                    negate => throw new Exception("non-ints in addition"),
                    add => throw new Exception("non-ints in addition")
                );
        }

        public bool hasZero()
        {
            return false;
        }

        public string toString()
        {
            return _expr
               .Match(
                   integer => integer.Content().ToString(),
                   negate => "-(" + new FP_OOP_Decomposition(_expr).toString() + ")",
                   add => "(" + new FP_OOP_Decomposition(add.Content1()).toString()
                        + " + " + new FP_OOP_Decomposition(add.Content2()).toString() + ")"
               );
        }
    }

    public class ExampleOfFP_OOP_Decomposition
    {
        public string Run()
        {
           return new FP_OOP_Decomposition(
                        new Expr(
                            new Add(
                                new Expr(new Integer(5)),
                                new Expr(
                                    new Add(
                                        new Expr(new Integer(-8)),
                                        new Expr(new Integer(6))
                                    )
                                )
                            )
                        )
                    ).toString()
        }      
    }
}
