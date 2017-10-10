using System;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_REMIT;
using Swift.Integration.Db.Models;
using Swift.Transformation.Common;

namespace Swift.Transformation.Rules.Contracts.MT103
{
    public class MT103_REMIT_Rule : TransformationRule<AsMT103_REMIT, B6MT103, DbDOCS_IN_SWIFT>
    {
        public MT103_REMIT_Rule(Func<AsMT103_REMIT, B6MT103> rule) : base(rule)
        {
        }

        protected override DbDOCS_IN_SWIFT Apply(B6MT103 transformedMessage)
        {
            throw new NotImplementedException();
        }
    }
}
