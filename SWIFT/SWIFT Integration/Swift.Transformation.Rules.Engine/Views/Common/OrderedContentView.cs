using System;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Rules.Engine.Views.Common
{
    public class OrderedContentView : IView
    {
        private readonly IEnumerable<IView> _content;

        public OrderedContentView(IEnumerable<IView> content)
        {
            _content = content;
        }
        public string View()
        {
            return String.Join(
                Environment.NewLine + Environment.NewLine,
                _content
                    .Select(fsc => fsc.View())
                    .OrderBy(x => x)
            );
        }

        public string Content()
        {
            throw new NotImplementedException();
        }
    }
}
