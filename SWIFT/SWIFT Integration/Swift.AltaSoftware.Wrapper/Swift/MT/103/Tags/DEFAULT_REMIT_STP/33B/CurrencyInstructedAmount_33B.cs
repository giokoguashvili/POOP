using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._33B
{
    public class CurrencyInstructedAmount_33B
    {
        public CurrencyInstructedAmount_33B(string tag33BValue)
        {
            Currency = tag33BValue.Substring(0, 3);
            Amount = new SwiftAmount(tag33BValue.Substring(3)).Value();
        }

        public string Currency { get; } 
        public decimal Amount { get;  }
    }
}