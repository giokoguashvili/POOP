using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Swift.Infrastructure.Infrastructure;
using Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig;

namespace Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap
{
    public class SwiftConfigSection : IContent<SwiftSection>
    {
        private readonly string _configSectionName;

        public SwiftConfigSection(string configSectionName)
        {
            _configSectionName = configSectionName;
        }
        public SwiftSection Content()
        {
            return (SwiftSection) WebConfigurationManager.GetSection(_configSectionName);
        }
    }
}
