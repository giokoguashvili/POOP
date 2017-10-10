using System;
using System.Collections;
using System.Collections.Generic;
using Swift.Transformation.Rules.Contracts.MT103;
using Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig;

namespace Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap
{
    public class FlatTransformationRuleElement : IEnumerable<SwiftConfigItem>
    {
        private readonly TransformationRuleElement _transformationRuleElement;

        public FlatTransformationRuleElement(TransformationRuleElement transformationRuleElement)
        {
            _transformationRuleElement = transformationRuleElement;
        }
        public IEnumerator<SwiftConfigItem> GetEnumerator()
        {
            var result = new List<SwiftConfigItem>();
            if (!String.IsNullOrEmpty(_transformationRuleElement.MT103_REMIT.ImplementationKey))
            {
                result.Add(
                    new SwiftConfigItem(
                        _transformationRuleElement.BankLTAdress,
                        _transformationRuleElement.MT103_REMIT.ImplementationKey,
                        typeof(MT103_REMIT_Rule)
                    )
                );
            }

            if (!String.IsNullOrEmpty(_transformationRuleElement.MT103_DEFAULT.ImplementationKey))
            {
                result.Add(
                    new SwiftConfigItem(
                        _transformationRuleElement.BankLTAdress,
                        _transformationRuleElement.MT103_DEFAULT.ImplementationKey,
                        typeof(MT103_DEFAULT_Rule)
                    )
                );
            }

            if (!String.IsNullOrEmpty(_transformationRuleElement.MT103_STP.ImplementationKey))
            {
                result.Add(
                    new SwiftConfigItem(
                        _transformationRuleElement.BankLTAdress,
                        _transformationRuleElement.MT103_STP.ImplementationKey,
                        typeof(MT103_STP_Rule)
                    )
                );
            }
            return result.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
