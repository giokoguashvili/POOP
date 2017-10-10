using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.AltaSoftware;

namespace Swift.Transformation.Rules.Engine.Store
{
    public class ImplementationKeyTransformationRules : IEnumerable<IAsTransformationRule>
    {
        private readonly IEnumerable<IAsTransformationRule> _asTransformatuinRules;
        private readonly IContent<string> _implementationKey;

        public ImplementationKeyTransformationRules(
            IEnumerable<IAsTransformationRule> asTransformatuinRules, 
            IContent<string> implementationKey)
        {
            _asTransformatuinRules = asTransformatuinRules;
            _implementationKey = implementationKey;
        }

        public IEnumerator<IAsTransformationRule> GetEnumerator()
        {
            return _asTransformatuinRules
                .Where(atr => atr.HasImplemetationKey(_implementationKey))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
