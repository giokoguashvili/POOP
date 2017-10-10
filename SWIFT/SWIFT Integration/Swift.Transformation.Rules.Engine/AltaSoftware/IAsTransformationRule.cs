using System;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.Infrastructure.Infrastructure;
using Swift.Integration.Db.Models;
using Swift.Transformation.Common;

namespace Swift.Transformation.Rules.Engine.AltaSoftware
{
    public interface IAsTransformationRule
    {
        ITransformationRule LoadedTransformationRuleInstance();
        bool HasImplemetationKey(IContent<string> implemetatonKey);
        TransformationRuleType TypeInfo();
        bool IsForBank(IContent<string> bankLTAdress);
        IDbModel Apply(IAsSwiftMessage asSwiftMessage);
        //IOptional<IEnumerable<TransformationRuleMap>> CorrespondingRulesMap(IContent<IEnumerable<TransformationRuleMap>> transformationRulesMap);
    }
}
