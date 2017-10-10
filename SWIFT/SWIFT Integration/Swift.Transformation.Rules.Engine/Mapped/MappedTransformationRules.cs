using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Engine.AltaSoftware;
using Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig;
using Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap;

namespace Swift.Transformation.Rules.Engine.Mapped
{
    public class MappedTransformationRules : IContent<IEnumerable<IOptional<IAsTransformationRule>>>
    {
        private readonly IContent<IEnumerable<SwiftConfigItem>> _flatedSwiftConfig;
        private readonly IContent<Dictionary<string, ITransformationRule>> _loadedAttributedParts;

        public MappedTransformationRules(
                IContent<Dictionary<string, ITransformationRule>> loadedAttributedParts,
                IContent<IEnumerable<SwiftConfigItem>> flatedSwiftConfig
            )
        {
            _flatedSwiftConfig = flatedSwiftConfig;
            _loadedAttributedParts = loadedAttributedParts;
        }




        public IEnumerable<IOptional<IAsTransformationRule>> Content()
        {
            return _flatedSwiftConfig
                .Content()
                .Select(fsc => new TransformationRuleMap(fsc)
                                        .CorrespondingTransformationRule(_loadedAttributedParts)
                           );
        }
    }

}
