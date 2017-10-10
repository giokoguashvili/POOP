using Swift.AltaSoftware.Wrapper.Swift.Common;
using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.K
{
    public class OptionKTests
    {
        [Theory]
        [InlineData(
            "/000104513118", 
            @"TRICHOSCIENCE INNOVATIONS INC.
400 455 GRANVILLE ST
VANCOUVER BC CA V6C 1T1", 
            @"/000104513118
TRICHOSCIENCE INNOVATIONS INC.
400 455 GRANVILLE ST
VANCOUVER BC CA V6C 1T1")]
        [InlineData(
            "/40817840713550000016",
            @"MOREV MIKHAIL BORISOVICH ,KRASNODAR
UL.ATARBEKOVA,35,KV.65", 
            @"/40817840713550000016
MOREV MIKHAIL BORISOVICH ,KRASNODAR
UL.ATARBEKOVA,35,KV.65")]
        [InlineData(
            null,
            @"BAYER HEALTHCARE LLC
555 WHITE PLAINS ROAD
TARRYTOWN             NY105915124",
            @"BAYER HEALTHCARE LLC
555 WHITE PLAINS ROAD
TARRYTOWN             NY105915124")]
        public void Method(string expAccount, string expNameAndAdress, string actTag50KValue)
        {
            Assert.Equal(
                        expAccount,
                        new OptionK(actTag50KValue).Account
                   );
            Assert.Equal(
                new SplitedByLines(expNameAndAdress).Value(),
                new OptionK(actTag50KValue).NameAndAdress
            );
        }
    }
}