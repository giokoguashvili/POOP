using System;
using System.Collections.Generic;
using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.Infrastructure.Infrastructure;
using Swift.Infrastructure.Infrastructure.Box;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Contracts.MT103;

namespace Swift.Transformation.Rules.Engine
{
    public class TransformationRuleType : IContent<IOptional<Type>>
    {
        private readonly ITransformationRule _transformationRule;

        public TransformationRuleType(ITransformationRule transformationRule)
        {
            _transformationRule = transformationRule;
        }

        public bool IsForMTMessage(IAsSwiftMessage asSwiftMessage)
        {
            return _transformationRule
                        .GetType()
                        
                        .BaseType
                        .GenericTypeArguments
                        .Any(gtat => gtat == asSwiftMessage.GetType());
        }

        public bool IsTransformationRuleType(Type transformationRuleType)
        {
            return _transformationRule.GetType().BaseType == transformationRuleType;
        }
        public IOptional<Type> Content()
        {
            return new Option<Type>(_transformationRule.GetType().BaseType);
            //return new FirstOptional<Type>(
            //        new Option<Type>(
            //            new List<Type>()
            //            {
            //                typeof(MT103_DEFAULT_Rule),
            //                typeof(MT103_REMIT_Rule),
            //                typeof(MT103_STP_Rule),
            //            }
            //            .Where(t => _transformationRule.GetType().BaseType == t)
            //        ), 
            //        new Option<Type>($"Unknow transformation rule type. Type: {_transformationRule.GetType()}")
            //    );
        }
    }
}
