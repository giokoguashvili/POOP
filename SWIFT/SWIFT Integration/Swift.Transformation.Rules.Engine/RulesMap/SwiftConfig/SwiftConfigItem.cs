using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap;
using Swift.Transformation.Rules.Engine.Views.SwiftConfig;

namespace Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig
{
    public class SwiftConfigItem : IView
    {
        private readonly string _bankLtAdress;
        private readonly string _implemetationKey;
        private readonly Type _mtMessageRuleType;

        public SwiftConfigItem(string bankLTAdress, string implemetationKey, Type mtMessageRuleType)
        {

            _bankLtAdress = bankLTAdress;
            _implemetationKey = implemetationKey;
            _mtMessageRuleType = mtMessageRuleType;
        }

        public IContent<string> BankLTAdress()
        {
            return new Box<string>(_bankLtAdress);
        }

        public Type MTMessageRuleType()
        {
            return _mtMessageRuleType;
        }

        public IContent<string> ImplementationKey()
        {
            return new Box<string>(_implemetationKey);
        }

        public bool Equal(SwiftConfigItem swiftConfigItem)
        {
            return
                swiftConfigItem.BankLTAdress().Content() == _bankLtAdress &&
                swiftConfigItem.ImplementationKey().Content() == _implemetationKey &&
                swiftConfigItem.MTMessageRuleType() == _mtMessageRuleType;
        }

        public string View()
        {
            return new RuleView(
                    _implemetationKey,
                    _mtMessageRuleType.ToString(),
                    _bankLtAdress
                ).Content();
        }
    }
}
