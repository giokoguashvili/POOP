using System;
using System.ComponentModel.Composition;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_REMIT;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Contracts.MT103;

namespace MT103.Transformation.Rule
{
    [Export(typeof(ITransformationRule))]
    [RuleInfo(ImplementationKey: "TBC", Name: nameof(MT103_STP_Rule))]
    public class MT103_STP_RuleImpl : MT103_STP_Rule
    {
        public MT103_STP_RuleImpl() :
            base((asSwiftMessage) =>
            {
                return new B6MT103();
            }){}
    }
}
