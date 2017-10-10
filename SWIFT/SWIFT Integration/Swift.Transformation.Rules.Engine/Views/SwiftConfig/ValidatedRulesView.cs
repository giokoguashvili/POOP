using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Rules.Engine.Views.SwiftConfig
{
    public class ValidatedRulesView : IView
    {
        private readonly IView _header;
        private readonly IView _body;

        public ValidatedRulesView(
                IView header,
                IView body
            )
        {
            _header = header;
            _body = body;
        }
        public string View()
        {
            return $@"
{_header.View()}

{_body.View()}";
        }
    }
}
