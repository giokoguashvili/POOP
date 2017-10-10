using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig
{
    public class FkFlatedSwiftConfig : IContent<IEnumerable<SwiftConfigItem>>
    {
        private readonly Tuple<List<SwiftConfigItem>, List<SwiftConfigItem>> _maps;
        public FkFlatedSwiftConfig()
        {
            _maps = new Tuple<List<SwiftConfigItem>, List<SwiftConfigItem>>(
                        new List<SwiftConfigItem>(), // for valid inputs
                        new List<SwiftConfigItem>()  // for invalid inputs
                    );
        }

        public IEnumerable<SwiftConfigItem> Content()
        {
            return _maps.Item1; // return all inputs
        }

        public IEnumerable<SwiftConfigItem> ExceptedSwiftConfigItems()
        {
            return _maps.Item2; // return only invalid inputs
        }

        public FkFlatedSwiftConfig ExceptExceptionOnThisConfig()
        {
            _maps.Item2.Add(_maps.Item1.Last());
            return this;
        }

        public FkFlatedSwiftConfig With(string bankLTAdress, string implemetationKey, Type mtMessageRuleType)
        {
            _maps.Item1.Add(new SwiftConfigItem(bankLTAdress, implemetationKey, mtMessageRuleType));
            return this;
        }
    }
}
