using System.Collections.Generic;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.Views.Common;

namespace Swift.Transformation.Rules.Engine.Views.SwiftConfig
{
    public class SuccessfulValidatedRulesView : IView
    {
        private readonly IContent<IEnumerable<IView>> _content;

        public SuccessfulValidatedRulesView(IEnumerable<IView> content)
            : this(new Box<IEnumerable<IView>>(content))
        {
            
        }
        public SuccessfulValidatedRulesView(IContent<IEnumerable<IView>> content)
        {
            _content = content;
        }
        public string View()
        {
            return new ValidatedRulesView(
                new SuccessfulValidationRulesHeader(),
                new OrderedContentView(_content.Content())
            ).View();
        }

        public override string ToString()
        {
            return View();
        }
    }
}
