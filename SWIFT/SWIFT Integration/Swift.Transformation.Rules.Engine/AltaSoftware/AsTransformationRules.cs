using System;
using System.Collections.Generic;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Engine.Mapped;
using Swift.Transformation.Rules.Engine.MEF;
using Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig;
using Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap;

namespace Swift.Transformation.Rules.Engine.AltaSoftware
{
    public class AsTransformationRules : IContent<IEnumerable<IAsTransformationRule>>
    {
        private readonly IContent<IEnumerable<SwiftConfigItem>> _flatedSwiftConfig;
        private readonly IContent<IEnumerable<Lazy<ITransformationRule, IDictionary<string, object>>>> _attributedParts;
        public AsTransformationRules(
                IContent<IEnumerable<SwiftConfigItem>> flatedSwiftConfig,
                IContent<IEnumerable<Lazy<ITransformationRule, IDictionary<string, object>>>> attributedParts
            )
        {
            _flatedSwiftConfig = flatedSwiftConfig;
            _attributedParts = attributedParts;
        }
        public IEnumerable<IAsTransformationRule> Content()
        {
            return new ValidatedMappedTransformationRules(
                        new MappedTransformationRules(
                            new LoadedAttributedParts<ITransformationRule>(
                                _attributedParts,
                                new ImplementationKeys(_flatedSwiftConfig)
                            ),
                            _flatedSwiftConfig
                        )
                    ).Content();
        }
    }
}
