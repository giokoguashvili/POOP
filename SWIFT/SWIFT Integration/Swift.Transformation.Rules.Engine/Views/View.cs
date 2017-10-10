using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Rules.Engine.Views
{
    public class ViewBox : IView
    {
        private readonly string _content;

        public ViewBox(string content)
        {
            _content = content;
        }
        public string View()
        {
            return _content;
        }
    }
}
