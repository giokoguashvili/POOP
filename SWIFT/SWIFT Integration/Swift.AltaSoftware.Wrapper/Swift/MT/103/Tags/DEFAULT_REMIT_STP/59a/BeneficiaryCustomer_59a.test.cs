using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using SWIFTFramework.Messages.Category1;
using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._59a
{
    public class BeneficiaryCustomer_59aTests
    {
        [Theory]
        [InlineData(
            "/GE42BR0000010696829863",
            @"CARGO MARKET LLC
KAZBEGI STR. 24G
TBILISI",
            @"{1:F01REPLGE22AXXX2860310234}{2:O1030851110223BKTRUS33AXXX05168911891102231751N}{3:{108:C764137OCP022311}{119:STP}}{4:
:20:C764137OCP022311
:23B:CRED
:32A:110223USD6862,00
:50K:/24106005249501
LYNX TRANS LLC
RA VANADZOR GRIBOEDOVI 6-31
:52A:/04437920
UNIJAM22XXX
:54A:SOGEUS33XXX
:59:/GE42BR0000010696829863
CARGO MARKET LLC
KAZBEGI STR. 24G
TBILISI
:70:PAYMENT FOR TRANSPORTATION
:71A:SHA
-}"
            )]
        [InlineData(
            null,
            @"CARGO MARKET LLC
KAZBEGI STR. 24G
TBILISI",
            @"{1:F01REPLGE22AXXX2860310234}{2:O1030851110223BKTRUS33AXXX05168911891102231751N}{3:{108:C764137OCP022311}{119:STP}}{4:
:20:C764137OCP022311
:23B:CRED
:32A:110223USD6862,00
:50K:/24106005249501
LYNX TRANS LLC
RA VANADZOR GRIBOEDOVI 6-31
:52A:/04437920
UNIJAM22XXX
:54A:SOGEUS33XXX
:59:CARGO MARKET LLC
KAZBEGI STR. 24G
TBILISI
:70:PAYMENT FOR TRANSPORTATION
:71A:SHA
-}"
        )]
        public void Tag59aNoLetterOptionTest(string expAccount, string expNameAndAdresses, string expRawSwiftMessage)
        {
            var mt = new MT103(
                new ParsedSwiftMessage(
                    new Mandator<string>(expRawSwiftMessage)
                ).First()
            );
            Assert.Equal(
                    expAccount,
                    new BeneficiaryCustomer_59a(
                        mt.BeneficiaryCustomer_59.Value,
                        mt.BeneficiaryCustomer_59A.Value,
                        mt.BeneficiaryCustomer_59F.Value
                   ).NoLetterOption.Account
                );
            Assert.Equal(
                new SplitedByLines(expNameAndAdresses).Value(), 
                new BeneficiaryCustomer_59a(
                    mt.BeneficiaryCustomer_59.Value,
                    mt.BeneficiaryCustomer_59A.Value,
                    mt.BeneficiaryCustomer_59F.Value
                ).NoLetterOption.NameAndAdress
            );
        }

        [Theory]
        [InlineData(
            "/GE05VT1000001980404506",
            @"ANA KVARELASHVILI
NAPAREULI
TELAVI",
            @"{1:F01UGEBGE22AXXX1097443006}{2:O1030806160408BYLADEMMAXXX30754883591604081006N}{3:{108:ZVP6932802/1}}{4:
:20:4210ZVP6932802
:23B:CRED
:32A:160725EUR4,
:33B:EUR4,
:50F:/DE73760501010011160025
1/Tamar Hanke
2/Weichselstr. 1
3/DE/90419 Nuernberg
:52A:SSKNDE77
:53A:OWHBDEFF
:57A:UGEBGE22
:59F:/GE05VT1000001980404506
ANA KVARELASHVILI
NAPAREULI
TELAVI
:70:UNTERHALT FUER ELTERN
:71A:SHA
-}"
        )]
        public void Tag59aOptionFTest(string expAccount, string expNameAndAdresses, string expRawSwiftMessage)
        {
            var mt = new MT103(
                new ParsedSwiftMessage(
                    new Mandator<string>(expRawSwiftMessage)
                ).First()
            );
            Assert.Equal(
                expAccount,
                new BeneficiaryCustomer_59a(
                    mt.BeneficiaryCustomer_59.Value,
                    mt.BeneficiaryCustomer_59A.Value,
                    mt.BeneficiaryCustomer_59F.Value
                ).OptionF.Account
            );
            Assert.Equal(
                new SplitedByLines(expNameAndAdresses).Value(),
                new BeneficiaryCustomer_59a(
                    mt.BeneficiaryCustomer_59.Value,
                    mt.BeneficiaryCustomer_59A.Value,
                    mt.BeneficiaryCustomer_59F.Value
                ).OptionF.NameAndAdress
            );
        }
    }
}
