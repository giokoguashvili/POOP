using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap
{
    public class MapExceptionMessageHeader : IContent<string>
    {
        public string Content()
        {
            return "Can't match rules!";
        }
    }
}
