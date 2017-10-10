using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.A
{
    public class OptionATests
    {
        [Theory]
        [InlineData("/293456-1254349-82", "VISTUS31", @"/293456-1254349-82
VISTUS31")]
        [InlineData(null, "VISTUS31", @"VISTUS31")]
        public void Method(string excAccount, string excIdentifierCode, string actTag50Avalue)
        {
            Assert.Equal(
                        excAccount,
                        new OptionA(actTag50Avalue).Account
                   );
            Assert.Equal(
                        excIdentifierCode,
                        new OptionA(actTag50Avalue).IdentifierCode
                    );
        }
    }
}