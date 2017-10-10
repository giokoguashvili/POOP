using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_DEFAULT;
using Swift.Integration.Db.Models;
using Swift.Transformation.Rules.Engine.Store;

namespace Swift.Integration.Domain.DmModels
{
    public class DmB6_MT103_DEFAULT_SwiftMessage : IDbModel<DbDOCS_IN_SWIFT>
    {
        private readonly IAsSwiftMessage<AsMT103_DEFAULT> _asMt103Default;
        private readonly ITransformationRulesStore _transformationRulesStore;


        public DmB6_MT103_DEFAULT_SwiftMessage(
                IAsSwiftMessage<AsMT103_DEFAULT> asMt103Default,
                ITransformationRulesStore transformationRulesStore)
        {
            _asMt103Default = asMt103Default;
            _transformationRulesStore = transformationRulesStore;
        }

        public DbDOCS_IN_SWIFT AsDbModel()
        {
            return _transformationRulesStore
                .RuleFor(_asMt103Default)
                .Select(rule => rule.Apply(_asMt103Default))
                .Select(tsm => new DbDOCS_IN_SWIFT())
                .First();
        }
    }



    //public class DmB6_SwiftMessage<TDbModel> : IDbModel<TDbModel>
    //{
    //    private readonly IAsSwiftMessage<TAsMT> _asMt103Default;
    //    private readonly ITransformationRulesStore _transformationRulesStore;


    //    public DmB6_SwiftMessage(
    //        IAsSwiftMessage<TAsMT> asMt103Default,
    //        ITransformationRulesStore transformationRulesStore)
    //    {
    //        _asMt103Default = asMt103Default;
    //        _transformationRulesStore = transformationRulesStore;
    //    }

    //    public TDbModel AsDbModel()
    //    {
    //        return _transformationRulesStore
    //            .Rule(typeof(ITransformationRule<TAsMT, TTransformationRuleOut>), _asMt103Default.BankLTAdress())
    //            .Select(rule => ((ITransformationRule<TAsMT, TTransformationRuleOut>)rule).Apply(_asMt103Default.Wrapped()))
    //            .Select(tsm => new TDbModel())
    //            .First();
    //        return null;
    //    }
    //}
}
