using System;
using System.ComponentModel.Composition;

namespace Swift.Transformation.Common
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class RuleInfoAttribute : ExportAttribute, IRuleInfo
    {
        public RuleInfoAttribute(string ImplementationKey, string Name)
        {
            this.ImplementationKey = ImplementationKey;
            this.Name = Name;
        }
        public string ImplementationKey { get; }
        public string Name { get; }
    }
}
