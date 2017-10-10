using SWIFTFramework.Messages.Category1;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._71F
{
    public class SendersCharges_71F
    {
        public SendersCharges_71F(Tag71F tag71F)
        {
            OptionF = new OptionF(tag71F);
        }
        public OptionF OptionF { get; }
    }
}
