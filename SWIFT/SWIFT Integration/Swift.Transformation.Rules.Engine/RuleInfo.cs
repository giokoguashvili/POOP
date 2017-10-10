using System.Collections.Generic;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Common;

namespace Swift.Transformation.Rules.Engine
{
    public class RuleInfo : IRuleInfo, IContent<IDictionary<string, object>>
    {
        private readonly IDictionary<string, object> _metaData;

        public RuleInfo(string implemetationKey, string name)
            : this(new Dictionary<string, object>()
            {
                [nameof(ImplementationKey)] = implemetationKey,
                [nameof(Name)] = name
            })
        {
            
        }
        public RuleInfo(IDictionary<string, object> metaData)
        {
            _metaData = metaData;
        }

        public string ImplementationKey => (string)_metaData[nameof(ImplementationKey)];
        public string Name => (string)_metaData[nameof(Name)];

        public IDictionary<string, object> Content()
        {
            return _metaData;
        }
    }
}
