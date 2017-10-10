using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap;

namespace Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig
{
    public class FlatedSwiftConfig : IContent<IEnumerable<SwiftConfigItem>>
    {
        private readonly IContent<SwiftSection> _swiftConfigSection;

        public FlatedSwiftConfig(IContent<SwiftSection> swiftConfigSection)
        {
            _swiftConfigSection = swiftConfigSection;
        }

        public IEnumerable<SwiftConfigItem> Content()
        {
            return _swiftConfigSection
                .Content()
                .TransformationRules
                .OfType<TransformationRuleElement>()
                .SelectMany(tre => new FlatTransformationRuleElement(tre));
        }

    }
}
