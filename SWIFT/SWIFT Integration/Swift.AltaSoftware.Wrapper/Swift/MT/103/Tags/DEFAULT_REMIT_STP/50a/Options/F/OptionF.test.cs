using Swift.AltaSoftware.Wrapper.Swift.Common;
using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.F
{
    public class OptionFTests
    {
        [Theory]
        [InlineData(
            "/12345678", 
            @"1/SMITH JOHN
2/299, PARK AVENUE
3/US/NEW YORK, NY 10017", 
            @"/12345678
1/SMITH JOHN
2/299, PARK AVENUE
3/US/NEW YORK, NY 10017")]
        [InlineData(
            "/BE30001216371411",
            @"1/PHILIPS MARK
4/19720830
5/BE/BRUSSELS",
            @"/BE30001216371411
1/PHILIPS MARK
4/19720830
5/BE/BRUSSELS")]
        [InlineData(
            "DRLC/BE/BRUSSELS/NB0949042",
            @"1/DUPONT JACQUES
2/HIGH STREET 6, APT 6C
3/BE/BRUSSELS",
            @"DRLC/BE/BRUSSELS/NB0949042
1/DUPONT JACQUES
2/HIGH STREET 6, APT 6C
3/BE/BRUSSELS")]
        [InlineData(
            "NIDN/DE/121231234342",
            @"1/MANN GEORG
6/DE/ABC BANK/1234578293",
            @"NIDN/DE/121231234342
1/MANN GEORG
6/DE/ABC BANK/1234578293")]
        [InlineData(
            "CUST/DE/ABC BANK/123456789/8-123456",
            @"1/MANN GEORG
2/LOW STREET 7
3/DE/FRANKFURT
8/7890",
            @"CUST/DE/ABC BANK/123456789/8-123456
1/MANN GEORG
2/LOW STREET 7
3/DE/FRANKFURT
8/7890")]
        public void Method(string excPartyIdentfier, string excNameAndAdress, string actTag50FValue)
        {
            Assert.Equal(
                        excPartyIdentfier,
                        new OptionF(actTag50FValue).PartyIdentifier
                   );

            Assert.Equal(
                        new SplitedByLines(excNameAndAdress).Value(),
                        new OptionF(actTag50FValue).NameAndAdress
                    );
        }
    }
}