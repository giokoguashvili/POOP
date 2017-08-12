using System;

public class Program
{
    public interface IDbModel { }
    public interface IDmModel { }

    public class DbMode : IDbModel { }
    public class DmModel : IDmModel { }
    public class Middle { }

    public interface IRule { }
    public interface IRule<in TInput, out TOutput> : IRule
        where TInput : IDmModel
        where TOutput : IDbModel
    {
        TOutput Apply(TInput elem);
    }


    public abstract class Rule<TDmModel, TMiddle, TDb> : IRule<IDmModel, TDb>
        where TDmModel : IDmModel
        where TDb : IDbModel
    {
        private readonly Func<TDmModel, TMiddle> _rule;
        protected Rule(Func<TDmModel, TMiddle> rule)
        {
            _rule = rule;
        }
        protected abstract TDb Apply(TMiddle transformedMessage);
        public TDb Apply(IDmModel elem)
        {
            throw new NotImplementedException();
        }
    }


    public class RuleA : Rule<DmModel, Middle, DbMode>
    {
        public RuleA(Func<DmModel, Middle> rule) : base(rule) { }
        protected override DbMode Apply(Middle transformedMessage)
        {
            throw new NotImplementedException();
        }
    }

    public class RuleB : RuleA
    {
        public RuleB() : base((dm) => new Middle()) { }
    }

    public static void Main()
    {
        var ruleB = (IRule<IDmModel, IDbModel>)new RuleB();
    }
}