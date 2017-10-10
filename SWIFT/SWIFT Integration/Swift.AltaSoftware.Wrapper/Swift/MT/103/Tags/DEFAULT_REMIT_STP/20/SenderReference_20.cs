using Swift.AltaSoftware.Wrapper.Swift.Common.Validators;
using SWIFTFramework;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._20
{
    public class SenderReference_20
    {
        public SenderReference_20(SwiftMessage swiftMessage)
            : this(swiftMessage.GetTagByName("20").Value)
        {
            
        }
        public SenderReference_20(string tag20Value)
        {
            Value = new MaximumLength(tag20Value, 16).Validated();
        }

        public string Value { get; }
    }
}