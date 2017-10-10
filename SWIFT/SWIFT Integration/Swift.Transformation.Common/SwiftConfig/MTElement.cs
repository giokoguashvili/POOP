using System.Configuration;

namespace Swift.Transformation.Common.SwiftConfig
{
    public class MTElement : ConfigurationElement
    {
        [ConfigurationProperty(PropertyNames.ImplementationKey, IsRequired = true)]
        public string ImplementationKey
        {
            get => (string)base[PropertyNames.ImplementationKey];
            set => base[PropertyNames.ImplementationKey] = value;
        }
    }
}