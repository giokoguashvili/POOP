using System;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.AltaSoftware;

namespace Swift.Transformation.Rules.Engine.Views.SwiftConfig
{
    public class ValidatedMappedTransformationRulesView : IView
    {
        private readonly IContent<IEnumerable<IAsTransformationRule>> _validatedMappedTransformationRules;

        public ValidatedMappedTransformationRulesView(IContent<IEnumerable<IAsTransformationRule>> validatedMappedTransformationRules)
        {
            _validatedMappedTransformationRules = validatedMappedTransformationRules;
        }

        public string View()
        {
            try
            {
                return new SuccessfulValidatedRulesView(
                    _validatedMappedTransformationRules
                        .Content()
                        .Select(vmtr => (IView)vmtr)
                ).View();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public override string ToString()
        {
            return View();
        }
    }

}
