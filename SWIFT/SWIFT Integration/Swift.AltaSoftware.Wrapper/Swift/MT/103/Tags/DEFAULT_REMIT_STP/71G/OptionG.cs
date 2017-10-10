using SWIFTFramework.Messages.Category1;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._71G
{
    public class OptionG
    {
        public OptionG(Tag71G tag71G)
        {
            Currency = tag71G.Currency;
            Amount = tag71G.Amount;
        }

        public string Currency { get; }
        public decimal Amount { get; }
    }
}
