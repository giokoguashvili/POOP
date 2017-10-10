using System;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using Swift.Transformation.Rules.Engine.AltaSoftware;
using Swift.Transformation.Rules.Engine.Views;
using Swift.Transformation.Rules.Engine.Views.SwiftConfig;

namespace Swift.Transformation.Rules.Engine.Mapped
{
    public class ValidatedMappedTransformationRules : IContent<IEnumerable<IAsTransformationRule>>
    {
        private readonly IContent<IEnumerable<IOptional<IAsTransformationRule>>> _mappedTransformationRules;

        public ValidatedMappedTransformationRules(
                IContent<IEnumerable<IOptional<IAsTransformationRule>>> mappedTransformationRules
            )
        {
            _mappedTransformationRules = mappedTransformationRules;
        }

        public IEnumerable<IAsTransformationRule> Content()
        {
            if (_mappedTransformationRules.Content().All(mtr => mtr.Fold(some: rule => true, nothing: m => false)))
            {
                return _mappedTransformationRules
                    .Content()
                    .SelectMany(mtrs => mtrs);
            }
            throw new Exception(
                new FaildValidatedRulesView(               
                    _mappedTransformationRules
                        .Content()
                        .Where(mtr => mtr.Fold(some: rule => false, nothing: m => true))
                        .SelectMany(mtr => mtr.Match(some: (a) => new ViewBox(""), nothing: (m) => new ViewBox(m)))
                ).View()
            );
        }
    }
}
