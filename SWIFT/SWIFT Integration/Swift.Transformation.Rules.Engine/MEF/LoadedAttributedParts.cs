using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap;

namespace Swift.Transformation.Rules.Engine.MEF
{
    public class LoadedAttributedParts<T> : IContent<Dictionary<string, T>>
    {
        private readonly IContent<IEnumerable<Lazy<T, IDictionary<string, object>>>> _attributedParts;
        private readonly IEnumerable<string> _implementationKeys;

        public LoadedAttributedParts(
                IContent<IEnumerable<Lazy<T, IDictionary<string, object>>>> attributedParts,
                IEnumerable<string> implementationKeys
            )
        {
            _attributedParts = attributedParts;
            _implementationKeys = implementationKeys;
        }


        public Dictionary<string, T> Content()
        {
            return _attributedParts
                .Content()
                .Where(lazy => new LoadedAttributedPart<T>(
                                    lazy,
                                    _implementationKeys
                               ).Content())
                .ToDictionary(
                    key => new RuleInfo(key.Metadata).ImplementationKey,
                    val => val.Value
                );
        }
    }


}
