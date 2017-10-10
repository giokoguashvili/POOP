using System;
using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_REMIT;
using Swift.Infrastructure.Infrastructure;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using Swift.Integration.Db.Models;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Engine.Store;
using SWIFTFramework;

namespace Swift.Integration.Domain
{
    public class TransformedSwiftMessage : IDbModel<IDbModel>
    {
        private readonly IAsSwiftMessage _asSwiftMessage;
        private readonly ITransformationRulesStore _transformationRulesStore;

        public TransformedSwiftMessage(
                IAsSwiftMessage asSwiftMessage,
                ITransformationRulesStore transformationRulesStore
            )
        {
            _asSwiftMessage = asSwiftMessage;
            _transformationRulesStore = transformationRulesStore;
        }

        public IDbModel AsDbModel()
        {
            return _transformationRulesStore
                .RuleFor(_asSwiftMessage)
                .Fold(
                    some: rule => rule.Apply(_asSwiftMessage),
                    nothing: m => throw new Exception(m)
                );
        }
    }
}
