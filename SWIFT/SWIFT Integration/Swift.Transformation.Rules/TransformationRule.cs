using System;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.Integration.Db.Models;
using Swift.Transformation.Common;

namespace Swift.Transformation.Rules
{
    public abstract class TransformationRule<TAsMT, TB6, TDb> : ITransformationRule<IAsSwiftMessage, TDb> 
        where TAsMT : IAsSwiftMessage
        where TDb : IDbModel
    {
        public readonly Func<TAsMT, TB6> Rule;
        protected TransformationRule(Func<TAsMT, TB6> rule)
        {
            Rule = rule;
        }
        protected abstract TDb Apply(TB6 transformedMessage);
        
        public TDb Apply(IAsSwiftMessage asSwiftMessage)
        {
            return Apply(Rule((TAsMT)asSwiftMessage));
        }
    }
}
