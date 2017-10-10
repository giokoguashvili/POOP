using System;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.Infrastructure.Infrastructure;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using Swift.Transformation.Rules.Engine.AltaSoftware;

namespace Swift.Transformation.Rules.Engine.Store
{
    public interface ITransformationRulesStore
    {
        //IOptional<MT103_DEFAULT_Rule> MT103_DEFAULT_Rule(IContent<string> bankLTAdress);

        //IOptional<MT103_REMIT_Rule> MT103_REMIT_Rule(IContent<string> bankLTAdress);

        //IOptional<MT103_STP_Rule> MT103_STP_Rule(IContent<string> bankLTAdress);
        //IOptional<T> Rule<T>(IContent<string> bankLTAdress)
        //    where T: ITransformationRule;

        //IOptional<IAsTransformationRule> Rule(Type asSwiftMessageType, IContent<string> bankLTAdress);
        IOptional<IAsTransformationRule> RuleFor(IAsSwiftMessage asSwiftMessage);
    }
}
