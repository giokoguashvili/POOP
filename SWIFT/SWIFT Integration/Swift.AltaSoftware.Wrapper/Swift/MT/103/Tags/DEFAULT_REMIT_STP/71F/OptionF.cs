using SWIFTFramework.Messages.Category1;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._71F
{
    public class OptionF
    {
        public OptionF(Tag71F tag71F)
        {
            Currency = tag71F.Currency;
            Amount = tag71F.Amount;
        }

        public string Currency { get; }
        public decimal Amount { get; }
    }
}
