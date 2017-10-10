using System;
using System.ComponentModel.Composition;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Contracts.MT103;

namespace MT103.Transformation.Rule
{
    [Export(typeof(ITransformationRule))]
    [RuleInfo(ImplementationKey: "TBC", Name: nameof(MT103_REMIT_Rule))]
    public class MT103_REMIT_RuleImpl : MT103_REMIT_Rule
    {
        public MT103_REMIT_RuleImpl() : base((asSwiftMessage) =>
        {
            return new B6MT103();
        }){}
    }
}
