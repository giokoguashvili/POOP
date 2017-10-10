using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift.MT._103;
using Swift.Transformation.Common.SwiftConfig;

namespace Swift.Transformation.Common.TransformationRulesMap
{
    public class TransformationRulesMap : IEnumerable<TransformationRuleMap>
    {
        private readonly SwiftSection _swiftSectionFromConfig;

        public TransformationRulesMap(SwiftSection swiftSectionFromConfig)
        {
            _swiftSectionFromConfig = swiftSectionFromConfig;
        }
        public IEnumerator<TransformationRuleMap> GetEnumerator()
        {
            return _swiftSectionFromConfig
                .TransformationRules
                .OfType<TransformationRuleElement>()
                .SelectMany(tre => new FlatTransformationRuleElement(tre))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class FlatTransformationRuleElement : IEnumerable<TransformationRuleMap>
    {
        private readonly TransformationRuleElement _transformationRuleElement;

        public FlatTransformationRuleElement(TransformationRuleElement transformationRuleElement)
        {
            _transformationRuleElement = transformationRuleElement;
        }
        public IEnumerator<TransformationRuleMap> GetEnumerator()
        {
            var result = new List<TransformationRuleMap>();
            if (!String.IsNullOrEmpty(_transformationRuleElement.MT103_REMIT.ImplementationKey))
            {
                result.Add(
                        new TransformationRuleMap(
                            _transformationRuleElement.BankLTAdress, 
                            new MT103_REMIT_Type().Content(), 
                            _transformationRuleElement.MT103_REMIT.ImplementationKey
                        )
                    );
            }

            if (!String.IsNullOrEmpty(_transformationRuleElement.MT103_DEFAULT.ImplementationKey))
            {
                result.Add(
                    new TransformationRuleMap<IMT103_DEFAULT_Rule>(
                        _transformationRuleElement.BankLTAdress,
                        _transformationRuleElement.MT103_DEFAULT.ImplementationKey
                    )
                );
            }

            if (!String.IsNullOrEmpty(_transformationRuleElement.MT103_STP.ImplementationKey))
            {
                result.Add(
                    new TransformationRuleMap(
                        _transformationRuleElement.BankLTAdress,
                        new MT103_STP_Type().Content(),
                        _transformationRuleElement.MT103_STP.ImplementationKey
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
