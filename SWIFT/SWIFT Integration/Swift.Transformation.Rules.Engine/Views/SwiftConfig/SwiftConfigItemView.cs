using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Rules.Engine.Views.SwiftConfig
{
    public class RuleView : IContent<string>
    {
        private readonly string _implementationKey;
        private readonly string _mtMessageRuleType;
        private readonly string _bankLtAdress;
        public RuleView(
                string implementationKey,
                string mtMessageRuleType,
                string bankLtAdress
            )
        {
            _implementationKey = implementationKey;
            _mtMessageRuleType = mtMessageRuleType;
            _bankLtAdress = bankLtAdress;
        }
        public string Content()
        {
            return $@"
    ImplementationKey:  {_implementationKey}
                 Type:  {_mtMessageRuleType}
         BankLTAdress:  {_bankLtAdress}";

        }
    }
}
