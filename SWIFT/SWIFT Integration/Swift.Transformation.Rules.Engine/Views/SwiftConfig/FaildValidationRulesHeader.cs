using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Rules.Engine.Views.SwiftConfig
{
    public class FaildValidationRulesHeader : IView
    {
        public string View()
        {
            return "Can't map rules:";
        }
    }
}
