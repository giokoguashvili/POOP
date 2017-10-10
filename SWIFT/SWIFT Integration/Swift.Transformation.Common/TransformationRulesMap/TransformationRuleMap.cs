using System;
using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Common.TransformationRulesMap
{
    public class TransformationRuleMap<TMTMessageRule>
    {
        private readonly string _bankLtAdress;
        private readonly string _implemetationKey;

        public TransformationRuleMap(string bankLTAdress, string implemetationKey)
        {
            
            _bankLtAdress = bankLTAdress;
            _implemetationKey = implemetationKey;
        }

        public IContent<string> BankLTAdress()
        {
            return new Box<string>(_bankLtAdress);
        }

        public Type MTMessageRuleType()
        {
            return typeof(TMTMessageRule);
        }

        public IContent<string> ImplementationKey()
        {
            return new Box<string>(_implemetationKey);
        }
    }
}
