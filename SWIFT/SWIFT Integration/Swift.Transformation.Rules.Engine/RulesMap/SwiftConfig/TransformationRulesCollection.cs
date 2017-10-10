using System;
using System.Configuration;

namespace Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig
{
    [ConfigurationCollection(
        typeof(TransformationRuleElement), 
        AddItemName = PropertyNames.TransformationRule, 
        CollectionType = ConfigurationElementCollectionType.BasicMap
    )]
    public class TransformationRulesCollection : ConfigurationElementCollection
    {
        public TransformationRuleElement this[int index]
        {
            get => (TransformationRuleElement)BaseGet(index);
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(TransformationRuleElement serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TransformationRuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TransformationRuleElement)element).BankLTAdress;
        }

        public void Remove(TransformationRuleElement serviceConfig)
        {
            BaseRemove(serviceConfig.BankLTAdress);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(String name)
        {
            BaseRemove(name);
        }
    }
}