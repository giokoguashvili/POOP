using System.Collections.Generic;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.Views.Common;

namespace Swift.Transformation.Rules.Engine.Views.SwiftConfig
{
    public class FaildValidatedRulesView : IView
    {
        private readonly IContent<IEnumerable<IView>> _content;

        public FaildValidatedRulesView(IEnumerable<IView> content)
            : this(new Box<IEnumerable<IView>>(content))
        {}
        public FaildValidatedRulesView(IContent<IEnumerable<IView>> content)
        {
            _content = content;
        }
        public string View()
        {
            return new ValidatedRulesView(
                new FaildValidationRulesHeader(),
                new OrderedContentView(_content.Content())
            ).View();
        }
    }

}
