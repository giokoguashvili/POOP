using MT103.Transformation.Rule;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Contracts.MT103;
using Swift.Transformation.Rules.Engine.AltaSoftware;
using Swift.Transformation.Rules.Engine.MEF;
using Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig;
using Swift.Transformation.Rules.Engine.Views.SwiftConfig;
using Xunit;

namespace Swift.Transformation.Rules.Engine.TransformationRules.AltaSoftware
{
    public class AsTransformationRulesTest
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(
                new SuccessfulValidatedRulesView(
                    new FkFlatedSwiftConfig()
                        .With("TBC", "key-1", typeof(MT103_REMIT_Rule))
                        .With("TBC", "key-2", typeof(MT103_STP_Rule))
                ).View(),
                new ValidatedMappedTransformationRulesView(
                    new AsTransformationRules(
                        new FkFlatedSwiftConfig()
                            .With("TBC", "key-1", typeof(MT103_REMIT_Rule))
                            .With("TBC", "key-2", typeof(MT103_STP_Rule)),
                        new FkAttributedParts()
                            .With(new MT103_REMIT_RuleImpl(), new RuleInfo("key-1", nameof(MT103_REMIT_Rule)))
                            .With(new MT103_STP_RuleImpl(), new RuleInfo("key-2", nameof(MT103_STP_Rule)))
                    )
                ).View()
            );
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(
                new SuccessfulValidatedRulesView(
                    new FkFlatedSwiftConfig()
                        .With("TBC", "key-1", typeof(MT103_REMIT_Rule))
                        .With("TBC", "key-2", typeof(MT103_STP_Rule))
                        .With("VTB", "key-1", typeof(MT103_REMIT_Rule))
                        .With("VTB", "key-2", typeof(MT103_STP_Rule))
                        .With("VTB", "key-3", typeof(MT103_STP_Rule))
                ).View(),
                new ValidatedMappedTransformationRulesView(
                    new AsTransformationRules(
                        new FkFlatedSwiftConfig()
                            .With("TBC", "key-1", typeof(MT103_REMIT_Rule))
                            .With("TBC", "key-2", typeof(MT103_STP_Rule))
                            .With("VTB", "key-1", typeof(MT103_REMIT_Rule))
                            .With("VTB", "key-2", typeof(MT103_STP_Rule))
                            .With("VTB", "key-3", typeof(MT103_STP_Rule)),
                        new FkAttributedParts()
                            .With(new MT103_REMIT_RuleImpl(), new RuleInfo("key-1", nameof(MT103_REMIT_Rule)))
                            .With(new MT103_STP_RuleImpl(), new RuleInfo("key-2", nameof(MT103_STP_Rule)))
                            .With(new MT103_STP_RuleImpl(), new RuleInfo("key-3", nameof(MT103_STP_Rule)))
                    )
                ).View()
            );
        }


        [Fact]
        public void Test3()
        {
            Assert.Equal(
                new FaildValidatedRulesView(
                    new FkFlatedSwiftConfig()
                        .With("TBC", "key-1", typeof(MT103_REMIT_Rule))
                ).View(),
                new ValidatedMappedTransformationRulesView(
                    new AsTransformationRules(
                        new FkFlatedSwiftConfig()
                            .With("TBC", "key-1", typeof(MT103_REMIT_Rule))
                            .With("TBC", "key-2", typeof(MT103_STP_Rule)),
                        new FkAttributedParts()
                            .With(new MT103_REMIT_RuleImpl(), new RuleInfo("key-3", nameof(MT103_REMIT_Rule)))
                            .With(new MT103_STP_RuleImpl(), new RuleInfo("key-2", nameof(MT103_STP_Rule)))
                    )
                ).View()
            );
        }

    }
}
