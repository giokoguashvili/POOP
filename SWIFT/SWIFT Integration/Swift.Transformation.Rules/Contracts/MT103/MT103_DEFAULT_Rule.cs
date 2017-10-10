using System;
using AutoMapper;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_DEFAULT;
using Swift.Integration.Db.Models;
using Swift.Transformation.Common;

namespace Swift.Transformation.Rules.Contracts.MT103
{
    public class MT103_DEFAULT_Rule : TransformationRule<AsMT103_DEFAULT, B6MT103, DbDOCS_IN_SWIFT>
    {
        public MT103_DEFAULT_Rule(Func<AsMT103_DEFAULT, B6MT103> rule) : base(rule)
        {
        }

        protected override DbDOCS_IN_SWIFT Apply(B6MT103 transformedMessage)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<B6MT103, DbDOCS_IN_SWIFT>();
            });

            return Mapper.Map<DbDOCS_IN_SWIFT>(transformedMessage);
        }
    }
}


