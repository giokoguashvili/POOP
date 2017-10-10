using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Common;

namespace Swift.Transformation.Rules.Engine.MEF
{
    public class FkAttributedParts : IContent<IEnumerable<Lazy<ITransformationRule, IDictionary<string, object>>>>
    {
        private readonly List<Lazy<ITransformationRule, IDictionary<string, object>>> _data;

        public FkAttributedParts()
        {
            _data = new List<Lazy<ITransformationRule, IDictionary<string, object>>>();
        }
        public IEnumerable<Lazy<ITransformationRule, IDictionary<string, object>>> Content()
        {
            return _data;
        }
        public FkAttributedParts With(ITransformationRule transformationRule, RuleInfo ruleInfo)
        {
           
            _data
                .Add(
                    new Lazy<ITransformationRule, IDictionary<string, object>>(
                        () => transformationRule,
                        ruleInfo.Content()
                    )
                );
            return this;
        }
    }
}
