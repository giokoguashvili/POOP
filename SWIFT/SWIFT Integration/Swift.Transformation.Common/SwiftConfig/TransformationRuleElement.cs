using System.Configuration;

namespace Swift.Transformation.Common.SwiftConfig
{
    public class TransformationRuleElement : ConfigurationElement
    {
        [ConfigurationProperty(PropertyNames.BankLTAdress, IsRequired = true, IsKey = true)]
        public string BankLTAdress
        {
            get => (string)base[PropertyNames.BankLTAdress];
            set => base[PropertyNames.BankLTAdress] = value;
        }

        [ConfigurationProperty(PropertyNames.MT103_DEFAULT, IsRequired = false)]
        public MTElement MT103_DEFAULT => (MTElement)this[PropertyNames.MT103_DEFAULT];

        [ConfigurationProperty(PropertyNames.MT103_REMIT, IsRequired = false)]
        public MTElement MT103_REMIT => (MTElement)this[PropertyNames.MT103_REMIT];

        [ConfigurationProperty(PropertyNames.MT103_STP, IsRequired = false)]
        public MTElement MT103_STP => (MTElement)this[PropertyNames.MT103_STP];
    }
}