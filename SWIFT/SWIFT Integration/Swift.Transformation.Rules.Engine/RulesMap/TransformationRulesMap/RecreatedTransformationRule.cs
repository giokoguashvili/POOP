using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Common;

namespace Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap
{
    public class RecreatedTransformationRule : IContent<KeyValuePair<string, ITransformationRule>>
    {
        private readonly KeyValuePair<string, ITransformationRule> _loadedAttributedPart;

        public RecreatedTransformationRule(KeyValuePair<string, ITransformationRule> loadedAttributedPart)
        {
            _loadedAttributedPart = loadedAttributedPart;
        }
        public KeyValuePair<string, ITransformationRule> Content()
        {
            var ruleType = _loadedAttributedPart.Value.GetType();
            return new KeyValuePair<string, ITransformationRule>(
                        _loadedAttributedPart.Key, 
                        (ITransformationRule)Activator
                            .CreateInstance(
                                ruleType.BaseType, 
                                ((dynamic)_loadedAttributedPart.Value).Rule)
                   );
        }
    }
}
