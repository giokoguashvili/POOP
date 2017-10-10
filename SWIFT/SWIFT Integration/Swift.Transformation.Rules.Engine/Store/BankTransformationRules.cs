using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.AltaSoftware;

namespace Swift.Transformation.Rules.Engine.Store
{
    public class BankTransformationRules : IEnumerable<IAsTransformationRule>
    {
        private readonly IEnumerable<IAsTransformationRule> _asTransformatuinRules;
        private readonly IAsSwiftMessage _asSwiftMessage;

        public BankTransformationRules(IEnumerable<IAsTransformationRule> asTransformatuinRules, IAsSwiftMessage asSwiftMessage)
        {
            _asTransformatuinRules = asTransformatuinRules;
            _asSwiftMessage = asSwiftMessage;
        }

        public IEnumerator<IAsTransformationRule> GetEnumerator()
        {
            return _asTransformatuinRules
                .Where(ast => ast.IsForBank(_asSwiftMessage.BankLTAdress()))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
