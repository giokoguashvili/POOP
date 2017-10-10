using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig;

namespace Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap
{
    public class ImplementationKeys: IEnumerable<string>
    {
        private readonly IContent<IEnumerable<SwiftConfigItem>> _flatedSwiftConfig;

        public ImplementationKeys(IContent<IEnumerable<SwiftConfigItem>> flatedSwiftConfig)
        {
            _flatedSwiftConfig = flatedSwiftConfig;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return _flatedSwiftConfig
                .Content()
                .Select(trm => trm.ImplementationKey().Content())
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
