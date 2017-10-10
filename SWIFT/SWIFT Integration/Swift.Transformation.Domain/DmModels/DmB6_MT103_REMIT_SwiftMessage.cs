using System;
using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_REMIT;
using Swift.Integration.Db.Models;
using Swift.Transformation.Rules.Engine.Store;

namespace Swift.Integration.Domain.DmModels
{
    public class DmB6_MT103_REMIT_SwiftMessage : IDbModel<DbDOCS_IN_SWIFT>
    {
        private readonly IAsSwiftMessage<AsMT103_REMIT> _asMt103Remit;
        private readonly ITransformationRulesStore _transformationRulesStore;


        public DmB6_MT103_REMIT_SwiftMessage(
                IAsSwiftMessage<AsMT103_REMIT> asMt103Remit,
                ITransformationRulesStore transformationRulesStore)
        {
            _asMt103Remit = asMt103Remit;
            _transformationRulesStore = transformationRulesStore;
        }

        public DbDOCS_IN_SWIFT AsDbModel()
        {
            throw  new NotImplementedException();
            //return _transformationRulesStore
            //    .MT103_REMIT_Rule(_asMt103Remit.BankLTAdress())
            //    .Select(rule => rule.Apply(_asMt103Remit.Wrapped()))
            //    .Select(tsm => new DbDOCS_IN_SWIFT())
            //    .First();
                //.MT103_REMIT_Rule(_asMt103Remit.BankLTAdress())
                //.Select(r => r.Apply(_asMt103Remit.Wrapped()))
                //.Select(s => new DbDOCS_IN_SWIFT())
                //.First();

            //return new DbDOCS_IN_SWIFT[0]
            //    .Concat(
            //        _asSwiftMessage
            //            .MT103_REMIT()
            //            .SelectMany(sm =>
            //                    _transformationRulesStore
            //                        .MT103_REMIT_Rule(new BankLTAdress(sm))
            //                        .Select(r => r.Apply(new AsMT103_REMIT(sm)))
            //            )
            //            .Select(s => new DbDOCS_IN_SWIFT())
            //    )
            //    .Concat(
            //        _asSwiftMessage
            //            .MT103_DEFAULT()
            //            .SelectMany(sm =>
            //                _transformationRulesStore
            //                    .MT103_DEFAULT_Rule(new BankLTAdress(sm))
            //                    .Select(r => r.Apply(new AsMT103_DEFAULT(sm)))
            //            )
            //            .Select(s => new DbDOCS_IN_SWIFT())
            //    )
            //    .Concat(
            //        _asSwiftMessage
            //            .MT103_STP()
            //            .SelectMany(sm =>
            //                _transformationRulesStore
            //                    .MT103_STP_Rule(new BankLTAdress(sm))
            //                    .Select(r => r.Apply(new AsMT103_STP(sm)))
            //            )
            //            .Select(s => new DbDOCS_IN_SWIFT())
            //    )
            //    .First();

            //return new DbDOCS_IN_SWIFT[0]
            //    .Concat(
            //        _asSwiftMessage
            //            .MT103_REMIT()
            //            .SelectMany(sm =>
            //                    _transformationRulesStore
            //                        .MT103_REMIT_Rule(new BankLTAdress(sm))
            //                        .Select(r => r.Apply(new AsMT103_REMIT(sm)))
            //            )
            //            .Select(s => new DbDOCS_IN_SWIFT())
            //    )
            //    .Concat(
            //        _asSwiftMessage
            //            .MT103_DEFAULT()
            //            .SelectMany(sm =>
            //                _transformationRulesStore
            //                    .MT103_DEFAULT_Rule(new BankLTAdress(sm))
            //                    .Select(r => r.Apply(new AsMT103_DEFAULT(sm)))
            //            )
            //            .Select(s => new DbDOCS_IN_SWIFT())
            //    )
            //    .Concat(
            //        _asSwiftMessage
            //            .MT103_STP()
            //            .SelectMany(sm =>
            //                _transformationRulesStore
            //                    .MT103_STP_Rule(new BankLTAdress(sm))
            //                    .Select(r => r.Apply(new AsMT103_STP(sm)))
            //            )
            //            .Select(s => new DbDOCS_IN_SWIFT())
            //    )
            //    .First();
        }
    }
}
