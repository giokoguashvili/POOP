using System;
using System.Collections.Generic;
using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.Infrastructure.Infrastructure;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Engine.AltaSoftware;

namespace Swift.Transformation.Rules.Engine.Store
{
    public class TransformationRulesStore : ITransformationRulesStore
    {
        private readonly IEnumerable<IAsTransformationRule> _mappedTransformationRules;
        public TransformationRulesStore(IEnumerable<IAsTransformationRule> mappedTransformationRules)
        {
            _mappedTransformationRules = mappedTransformationRules;
        }

        public IOptional<IAsTransformationRule> RuleFor(IAsSwiftMessage asSwiftMessage)
        {
            return new Option<IAsTransformationRule>(
                new MTMessageRuleTypeTransformationRule(
                    new BankTransformationRules(
                        _mappedTransformationRules,
                        asSwiftMessage
                    ),
                    asSwiftMessage
                )
            );
        }
    }
}

//public IOptional<T> Rule<T>(IContent<string> bankLTAdress) where T: ITransformationRule
//{
//    return new Option<T>(
//        new MTMessageRuleTypeTransformationRule(
//            new BankTransformationRules(
//                _mappedTransformationRules,
//                bankLTAdress
//            ),
//            typeof(T)
//        )
//        .Select(tr => (T)tr.LoadedTransformationRuleInstance())
//    );
//}

//public IOptional<IAsTransformationRule> Rule(Type asSwiftMessageType, IContent<string> bankLTAdress)
//{
//    return new Option<IAsTransformationRule>(
//        new MTMessageRuleTypeTransformationRule(
//                new BankTransformationRules(
//                    _mappedTransformationRules,
//                    bankLTAdress
//                ),
//                asSwiftMessageType
//            )
//            //.Select(tr => new AsTransformationRule(new KeyValuePair<string, ITransformationRule>("", tr.LoadedTransformationRuleInstance()), bankLTAdress))
//    );
//}
//public IOptional<ITransformationRule> Rule(Type ruleType, IContent<string> bankLTAdress)
//{
//    return new Option<ITransformationRule>(
//        new MTMessageRuleTypeTransformationRule(
//                new BankTransformationRules(
//                    _mappedTransformationRules,
//                    bankLTAdress
//                ),
//                ruleType
//            )
//            .Select(tr => tr.LoadedTransformationRuleInstance())
//    );
//}

//public IOptional<MT103_DEFAULT_Rule> MT103_DEFAULT_Rule(IContent<string> bankLTAdress)
//{
//    return new Option<MT103_DEFAULT_Rule>(
//        new MTMessageRuleTypeTransformationRule(
//            new BankTransformationRules(
//                _mappedTransformationRules,
//                bankLTAdress
//            ),
//            typeof(MT103_DEFAULT_Rule)
//        )
//        .Select(tr => new MT103_DEFAULT_TransformationRule(tr.LoadedTransformationRuleInstance()))
//    );
//}
//public IOptional<MT103_REMIT_Rule> MT103_REMIT_Rule(IContent<string> bankLTAdress)
//{
//    return new Option<MT103_REMIT_Rule>(
//            new MTMessageRuleTypeTransformationRule(
//                new BankTransformationRules(
//                    _mappedTransformationRules,
//                    bankLTAdress
//                ),
//                typeof(MT103_REMIT_Rule)
//            )
//            .Select(tr => new MT103_REMIT_TransformationRule(tr.LoadedTransformationRuleInstance()))
//    );
//}

//public IOptional<MT103_STP_Rule> MT103_STP_Rule(IContent<string> bankLTAdress)
//{
//    return new Option<MT103_STP_Rule>(
//                new MTMessageRuleTypeTransformationRule(
//                    new BankTransformationRules(
//                        _mappedTransformationRules,
//                        bankLTAdress
//                    ),
//                    typeof(MT103_STP_Rule)
//                )
//                .Select(tr => new MT103_STP_TransformationRule(tr.LoadedTransformationRuleInstance()))
//            );
//}