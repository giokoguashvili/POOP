using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Rules.Engine.Views.SwiftConfig
{
    public class SuccessfulValidationRulesHeader : IView
    {
        public string View()
        {
            return "Mapped rules:";
        }
    }
}
