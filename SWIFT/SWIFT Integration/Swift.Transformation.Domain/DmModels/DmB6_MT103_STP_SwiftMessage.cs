using System;
using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_STP;
using Swift.Integration.Db.Models;
using Swift.Transformation.Rules.Engine.Store;

namespace Swift.Integration.Domain.DmModels
{
    public class DmB6_MT103_STP_SwiftMessage : IDbModel<DbDOCS_IN_SWIFT>
    {
        private readonly IAsSwiftMessage<AsMT103_STP> _asMt103Stp;
        private readonly ITransformationRulesStore _transformationRulesStore;


        public DmB6_MT103_STP_SwiftMessage(
                IAsSwiftMessage<AsMT103_STP> asMt103Stp,
                ITransformationRulesStore transformationRulesStore)
        {
            _asMt103Stp = asMt103Stp;
            _transformationRulesStore = transformationRulesStore;
        }

        public DbDOCS_IN_SWIFT AsDbModel()
        {
            throw new NotImplementedException();
            //return _transformationRulesStore
            //    .MT103_STP_Rule(_asMt103Stp.BankLTAdress())
            //    .Select(rule => rule.Apply(_asMt103Stp.Wrapped()))
            //    .Select(tsm => new DbDOCS_IN_SWIFT())
            //    .First();
        }
    }
}
