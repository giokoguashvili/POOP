using SWIFTFramework.Validation;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103
{
    public class Tag20Validator: ValidateTagBase
    {
        public Tag20Validator() : this(true)
        {}
        public Tag20Validator(bool allowEmptyValue) : base("20", allowEmptyValue)
        {}

        protected override void InitializeRules()
        {
            Rules.Add(new ValidationRule_Length(0, 16));
        }
    }
}