using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Engine.AltaSoftware;
using Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig;

namespace Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap
{
    public class TransformationRuleMap
    {
        private readonly SwiftConfigItem _swiftConfigItem;

        public TransformationRuleMap(SwiftConfigItem swiftConfigItem)
        {
            _swiftConfigItem = swiftConfigItem;
        }

        public IOptional<IAsTransformationRule> CorrespondingTransformationRule(IContent<Dictionary<string, ITransformationRule>> loadedAttributedParts)
        {
            var coresspondingTransformationRule = loadedAttributedParts
                .Content()
                .Where(lap => lap.Key.Equals(_swiftConfigItem.ImplementationKey().Content())
                              && new TransformationRuleType(lap.Value)
                                  .Content()
                                  .Fold(
                                      some: (trt) => trt == _swiftConfigItem.MTMessageRuleType(),
                                      nothing: (m) => throw new Exception(m)
                                  )
                )
                .ToArray();

            if (coresspondingTransformationRule.Count() > 1)
            {
                return new Option<IAsTransformationRule>(
                    $@"Dublicated transformation rule with ImplementationKey: {_swiftConfigItem.ImplementationKey()}, Type: {_swiftConfigItem.MTMessageRuleType()}"
                );
            }

            if (coresspondingTransformationRule.Any())
            {
                return new Option<IAsTransformationRule>(
                    coresspondingTransformationRule
                        .Select(ctr => new AsTransformationRule(
                                            new RecreatedTransformationRule(ctr).Content(), 
                                            _swiftConfigItem.BankLTAdress())
                                       )
                        .First()
                );
            }
            else
            {
                return new Option<IAsTransformationRule>(
                    _swiftConfigItem.View()
                );
            }
        }
    }
}
