using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Rules.Engine.Views.MtRule
{
    public class FaildVeficationSwiftConfigHeader : IView
    {
        public string View()
        {
            return "Invalid config, dublicated rules per bank";
        }
    }
}
