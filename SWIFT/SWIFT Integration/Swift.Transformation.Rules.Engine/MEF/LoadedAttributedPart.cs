using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap;

namespace Swift.Transformation.Rules.Engine.MEF
{
    public class LoadedAttributedPart<T> : IContent<bool>
    {
        private readonly Lazy<T, IDictionary<string, object>> _attributedPart;
        private readonly IEnumerable<string> _implementationKeys;

        public LoadedAttributedPart(
            Lazy<T, IDictionary<string, object>> attributedPart,
            IEnumerable<string> implementationKeys
        )
        {
            _attributedPart = attributedPart;
            _implementationKeys = implementationKeys;
        }

        public bool Content()
        {
            return _implementationKeys
                .Contains(
                    new RuleInfo(_attributedPart.Metadata)
                        .ImplementationKey
                 );
        }
    }
}
