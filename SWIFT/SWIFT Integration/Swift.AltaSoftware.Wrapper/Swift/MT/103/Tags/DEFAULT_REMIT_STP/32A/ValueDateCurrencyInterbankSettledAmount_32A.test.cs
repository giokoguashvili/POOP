using System;
using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._32A
{
    public class ValueDateCurrencyInterbankSettledAmount_32ATests
    {
        [Theory]
        [InlineData(1998, 12, 09, "USD", "1000.00", "981209USD1000,00")]
        public void Method(int yy, int mm, int dd, string currency, decimal amount, string actTag32AValue)
        {
            
            Assert.Equal(
                    new DateTime(yy, mm, dd),
                    new ValueDateCurrencyInterbankSettledAmount_32A(actTag32AValue).Date
                );
            Assert.Equal(
                currency,
                new ValueDateCurrencyInterbankSettledAmount_32A(actTag32AValue).Currency
            );
            Assert.Equal(
                amount,
                new ValueDateCurrencyInterbankSettledAmount_32A(actTag32AValue).Amount
            );
        }
    }
}