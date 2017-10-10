using System;
using System.Collections.Generic;
using System.Dynamic;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.Infrastructure.Infrastructure;
using Swift.Integration.Db.Models;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Engine.Views.SwiftConfig;

namespace Swift.Transformation.Rules.Engine.AltaSoftware
{

    public class AsTransformationRule : IAsTransformationRule, IView
    {
        private readonly KeyValuePair<string, ITransformationRule> _loadedAttributedPart;
        private readonly IContent<string> _bankLtAdress;
        public AsTransformationRule(
                KeyValuePair<string, ITransformationRule> loadedAttributedPart,
                IContent<string> bankLtAdress
            )
        {
            _loadedAttributedPart = loadedAttributedPart;
            _bankLtAdress = bankLtAdress;
        }

        public ITransformationRule LoadedTransformationRuleInstance()
        {
            return _loadedAttributedPart.Value;
        }

        public bool HasImplemetationKey(IContent<string> implemetatonKey)
        {
            return implemetatonKey.Content().Equals(_loadedAttributedPart.Key);
        }

        public TransformationRuleType TypeInfo()
        {
            return new TransformationRuleType(_loadedAttributedPart.Value);
        }

        public bool IsForBank(IContent<string> bankLtAdress)
        {
            return _bankLtAdress.Content().Equals(bankLtAdress.Content());
        }

        public IDbModel Apply(IAsSwiftMessage asSwiftMessage)
        {
            
            //var res = _loadedAttributedPart
            //    .Value
            //    .GetType()
            //    .GetMethod("Apply")
            //    .Invoke(_loadedAttributedPart.Value, new[] { asSwiftMessage });
            ////Convert.ChangeType((dynamic) res, null);
            return ((ITransformationRule<IAsSwiftMessage, IDbModel>)_loadedAttributedPart.Value).Apply(asSwiftMessage); 
        }

        //public IOptional<IEnumerable<TransformationRuleMap>> CorrespondingRulesMap(IContent<IEnumerable<TransformationRuleMap>> transformationRulesMap)
        //{
        //    return new FirstOptional<IEnumerable<TransformationRuleMap>>(
        //        new Option<IEnumerable<TransformationRuleMap>>(
        //            transformationRulesMap
        //                .Content()
        //                .Where(trm => trm.ImplementationKey().Content().Equals(_loadedAttributedPart.Key)
        //                              && trm.MTMessageRuleType() == new TransformationRuleType(_loadedAttributedPart.Value).Content()
        //                )
        //        ),
        //        new Option<IEnumerable<TransformationRuleMap>>(
        //            $@"Can't map transformation rule with 
        //                        \n MTMessageRuleType: {new TransformationRuleType(_loadedAttributedPart.Value).Content()}
        //                        \n ImplementationKey: {_loadedAttributedPart.Key}
        //                        "
        //        )
        //    );
        //}
        public string View()
        {
            return new RuleView(
                        _loadedAttributedPart.Key,
                        new TransformationRuleType(_loadedAttributedPart.Value)
                            .Content()
                            .Fold(typeof(ITransformationRule))
                            .ToString(),
                        _bankLtAdress.Content()
                   ).Content();
        }
    }
}
