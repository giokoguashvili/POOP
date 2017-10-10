using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._33B
{
    public class CurrencyInstructedAmount_33BTests
    {
        [Theory]
        [InlineData("USD", 1000.00, "USD1000,00")]
        public void Method(string expCurrency, decimal expAmount, string actTag33BValue)
        {
            Assert.Equal(
                    expCurrency,
                    new CurrencyInstructedAmount_33B(actTag33BValue).Currency
                );

            Assert.Equal(
                expAmount,
                new CurrencyInstructedAmount_33B(actTag33BValue).Amount
            );
        }
    }
}