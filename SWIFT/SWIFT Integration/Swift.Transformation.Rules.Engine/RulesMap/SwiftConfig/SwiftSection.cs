using System.Configuration;

namespace Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig
{
    public sealed class SwiftSection : ConfigurationSection
    {
        [ConfigurationProperty(PropertyNames.TransformationRules, IsDefaultCollection = true, IsKey = false, IsRequired = true)]
        public TransformationRulesCollection TransformationRules => base[PropertyNames.TransformationRules] as TransformationRulesCollection;
    }
}