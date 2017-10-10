using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using SWIFTFramework.Messages.Category1;
using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._53a
{
    public class SendersCorrespondent_53aTests
    {
        [Theory]
        [InlineData(
            null,
            "OWHBDEFF",
            @"{1:F01UGEBGE22AXXX1097443006}{2:O1030806160408BYLADEMMAXXX30754883591604081006N}{3:{108:ZVP6932802/1}}{4:
:20:4210ZVP6932802
:23B:CRED
:32A:160725USD4,
:33B:USD4,
:50F:/DE73760501010011160025
1/Tamar Hanke
2/Weichselstr. 1
3/DE/90419 Nuernberg
:52A:SSKNDE77
:53A:OWHBDEFF
:57A:UGEBGE22
:59F:/GE05VT1000001980404506
1/ANA KVARELASHVILI
NAPAREULI
TELAVI
:70:UNTERHALT FUER ELTERN
:71A:SHA
-}"
            )]
        [InlineData(
            "/AAA/BBB",
            "OWHBDEFF",
            @"{1:F01UGEBGE22AXXX1097443006}{2:O1030806160408BYLADEMMAXXX30754883591604081006N}{3:{108:ZVP6932802/1}}{4:
:20:4210ZVP6932802
:23B:CRED
:32A:160725USD4,
:33B:USD4,
:50F:/DE73760501010011160025
1/Tamar Hanke
2/Weichselstr. 1
3/DE/90419 Nuernberg
:52A:SSKNDE77
:53A:/AAA/BBB
OWHBDEFF
:57A:UGEBGE22
:59F:/GE05VT1000001980404506
1/ANA KVARELASHVILI
NAPAREULI
TELAVI
:70:UNTERHALT FUER ELTERN
:71A:SHA
-}"
        )]
        public void Test53aOptionA(string expPartyIdentifier, string expIdentifierCode, string expRawSwiftMessage)
        {
            var mt = new MT103(
                        new ParsedSwiftMessage(
                            new Mandator<string>(expRawSwiftMessage)
                        ).First()
                    );

            Assert.Equal(
                        expPartyIdentifier,
                        new SendersCorrespondent_53a(
                            mt.SendersCorrespondent_53A.Value,
                            mt.SendersCorrespondent_53B.Value,
                            mt.SendersCorrespondent_53D.Value
                        ).OptionA.PartyIdentifier
                   );

            Assert.Equal(
                        expIdentifierCode,
                        new SendersCorrespondent_53a(
                            mt.SendersCorrespondent_53A.Value,
                            mt.SendersCorrespondent_53B.Value,
                            mt.SendersCorrespondent_53D.Value
                        ).OptionA.IdentifierCode
                    );
        }

        [Theory]
        [InlineData(
            null,
            "OWHBDEFF",
            @"{1:F01UGEBGE22AXXX1097443006}{2:O1030806160408BYLADEMMAXXX30754883591604081006N}{3:{108:ZVP6932802/1}}{4:
:20:4210ZVP6932802
:23B:CRED
:32A:160725USD4,
:33B:USD4,
:50F:/DE73760501010011160025
1/Tamar Hanke
2/Weichselstr. 1
3/DE/90419 Nuernberg
:52A:SSKNDE77
:53B:OWHBDEFF
:57A:UGEBGE22
:59F:/GE05VT1000001980404506
1/ANA KVARELASHVILI
NAPAREULI
TELAVI
:70:UNTERHALT FUER ELTERN
:71A:SHA
-}"
        )]
        [InlineData(
            "/AAA/BBB",
            "OWHBDEFF",
            @"{1:F01UGEBGE22AXXX1097443006}{2:O1030806160408BYLADEMMAXXX30754883591604081006N}{3:{108:ZVP6932802/1}}{4:
:20:4210ZVP6932802
:23B:CRED
:32A:160725USD4,
:33B:USD4,
:50F:/DE73760501010011160025
1/Tamar Hanke
2/Weichselstr. 1
3/DE/90419 Nuernberg
:52A:SSKNDE77
:53B:/AAA/BBB
OWHBDEFF
:57A:UGEBGE22
:59F:/GE05VT1000001980404506
1/ANA KVARELASHVILI
NAPAREULI
TELAVI
:70:UNTERHALT FUER ELTERN
:71A:SHA
-}"
        )]
        public void Test53aOptionB(string expPartyIdentifier, string expLocation, string expRawSwiftMessage)
        {
            var mt = new MT103(
                new ParsedSwiftMessage(
                    new Mandator<string>(expRawSwiftMessage)
                ).First()
            );

            Assert.Equal(
                expPartyIdentifier,
                new SendersCorrespondent_53a(
                    mt.SendersCorrespondent_53A.Value,
                    mt.SendersCorrespondent_53B.Value,
                    mt.SendersCorrespondent_53D.Value
                ).OptionB.PartyIdentifier
            );

            Assert.Equal(
                expLocation,
                new SendersCorrespondent_53a(
                    mt.SendersCorrespondent_53A.Value,
                    mt.SendersCorrespondent_53B.Value,
                    mt.SendersCorrespondent_53D.Value
                ).OptionB.Location
            );
        }

        [Theory]
        [InlineData(
            "/AAA/BBB",
            "OWHBDEFF",
            @"{1:F01UGEBGE22AXXX1097443006}{2:O1030806160408BYLADEMMAXXX30754883591604081006N}{3:{108:ZVP6932802/1}}{4:
:20:4210ZVP6932802
:23B:CRED
:32A:160725USD4,
:33B:USD4,
:50F:/DE73760501010011160025
1/Tamar Hanke
2/Weichselstr. 1
3/DE/90419 Nuernberg
:52A:SSKNDE77
:53D:/AAA/BBB
OWHBDEFF
:57A:UGEBGE22
:59F:/GE05VT1000001980404506
1/ANA KVARELASHVILI
NAPAREULI
TELAVI
:70:UNTERHALT FUER ELTERN
:71A:SHA
-}"
        )]
        [InlineData(
            "/AAA/BBB",
            @"OWHBDEFF
BDEFF",
            @"{1:F01UGEBGE22AXXX1097443006}{2:O1030806160408BYLADEMMAXXX30754883591604081006N}{3:{108:ZVP6932802/1}}{4:
:20:4210ZVP6932802
:23B:CRED
:32A:160725USD4,
:33B:USD4,
:50F:/DE73760501010011160025
1/Tamar Hanke
2/Weichselstr. 1
3/DE/90419 Nuernberg
:52A:SSKNDE77
:53D:/AAA/BBB
OWHBDEFF
BDEFF
:57A:UGEBGE22
:59F:/GE05VT1000001980404506
1/ANA KVARELASHVILI
NAPAREULI
TELAVI
:70:UNTERHALT FUER ELTERN
:71A:SHA
-}"
        )]
        [InlineData(
            null,
            @"OWHBDEFF
BDEFF",
            @"{1:F01UGEBGE22AXXX1097443006}{2:O1030806160408BYLADEMMAXXX30754883591604081006N}{3:{108:ZVP6932802/1}}{4:
:20:4210ZVP6932802
:23B:CRED
:32A:160725USD4,
:33B:USD4,
:50F:/DE73760501010011160025
1/Tamar Hanke
2/Weichselstr. 1
3/DE/90419 Nuernberg
:52A:SSKNDE77
:53D:OWHBDEFF
BDEFF
:57A:UGEBGE22
:59F:/GE05VT1000001980404506
1/ANA KVARELASHVILI
NAPAREULI
TELAVI
:70:UNTERHALT FUER ELTERN
:71A:SHA
-}"
        )]
        public void Test53aOptionD(string expPartyIdentifier, string expNameAndAdress, string expRawSwiftMessage)
        {
            var mt = new MT103(
                new ParsedSwiftMessage(
                    new Mandator<string>(expRawSwiftMessage)
                ).First()
            );

            Assert.Equal(
                expPartyIdentifier,
                new SendersCorrespondent_53a(
                    mt.SendersCorrespondent_53A.Value,
                    mt.SendersCorrespondent_53B.Value,
                    mt.SendersCorrespondent_53D.Value
                ).OptionD.PartyIdentifier
            );

            Assert.Equal(
                new SplitedByLines(expNameAndAdress).Value(),
                new SendersCorrespondent_53a(
                    mt.SendersCorrespondent_53A.Value,
                    mt.SendersCorrespondent_53B.Value,
                    mt.SendersCorrespondent_53D.Value
                ).OptionD.NameAndAdress
            );
        }
    }
}