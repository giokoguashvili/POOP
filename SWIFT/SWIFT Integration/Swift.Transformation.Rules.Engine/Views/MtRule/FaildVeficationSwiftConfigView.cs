using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.Views.Common;
using Swift.Transformation.Rules.Engine.Views.SwiftConfig;

namespace Swift.Transformation.Rules.Engine.Views.MtRule
{
    public class FaildVeficationSwiftConfigView : IView
    {
        private readonly IEnumerable<IView> _content;

        public FaildVeficationSwiftConfigView(IEnumerable<IView> content)
        {
            _content = content;
        }
        public string View()
        {
            return new ValidatedRulesView(
                new FaildVeficationSwiftConfigHeader(),
                new OrderedContentView(_content)
            ).View();
        }
    }
}
