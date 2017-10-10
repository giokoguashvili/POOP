using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using SWIFTFramework.Messages.Category1;
using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._52a
{
    public class OrderingInstitution_52aTests
    {
        [Theory]
        [InlineData(
            "/04437920",
            "UNIJAM22XXX",
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
-}")]
        [InlineData(
            null,
            "BYBAAM22",
            @"{1:F01REPLGE22AXXX2860310214}{2:O1031439110223COBADEFFDXXX26316445591102231740N}{3:{119:STP}}{4:
:20:FAAS105405553600
:23B:CRED
:32A:110223USD3951,55
:50K:/2140002575320101
C AND F CO LLC
SEBASTIA STR.66
YEREVAN ARMENIA
:52A:BYBAAM22
:59:/3618037397
INTEGRATED BUSINESS SOLUTIONS LTD
42, A.KAZBEGI AVE.
TBILISI GEORGIA
:70:INVOICE N S440-1/10 DD 15.11.2010
:71A:OUR
-}")]
        [InlineData(
            null,
            "HANDSESS",
            @"{1:F01CPTBGE22AXXX0202009386}{2:O1030737151123COBADEFFEXXX05402475501511231423N}{3:{119:STP}}{4:
:20:FAAS532701417800
:23B:CRED
:32A:151123EUR1030,00
:33B:EUR1030,00
:50K:/SE6060000000000181071592
KJELLBOM, GUNILLA
DALANGSVAGEN 15
862 34  KVISSLEBY
:52A:HANDSESS
:59:/GE35IN0036920002741601
ONE PAYMENTS LTD
CAPITAL BANK
TBILISI
TBILISI
:70:USERNAME ASENG PROTRADER
:71A:OUR
-}")]
        public void TestOptionA(string expPartyIdentifier, string expIdentifierCode, string actMT103Message)
        {
            var mt103Message = new MT103(
                                    new ParsedSwiftMessage(
                                        new Mandator<string>(actMT103Message)
                                    ).Content().First()
                               );
            Assert.Equal(
                        expPartyIdentifier,
                        new OrderingInstitution_52a(
                            mt103Message.OrderingInstitution_52A.Value,
                            mt103Message.OrderingInstitution_52D.Value
                        ).OptionA.PartyIdentifier
                    );

            Assert.Equal(
                        expIdentifierCode,
                        new OrderingInstitution_52a(
                            mt103Message.OrderingInstitution_52A.Value,
                            mt103Message.OrderingInstitution_52D.Value
                        ).OptionA.IdentifierCode
                    );
        }

        [Theory]
        [InlineData(
            "//FW221272316",
            "HUDSON CITY SAVINGS BANK FSB",
            @"{1:F01ALTAGE22AXXX3423061651}{2:O1031533110331BKTRUS33AXXX05513552231103312333N}{3:{108:M108422IFD033111}}{4:
:20:M108422IFD033111
:23B:CRED
:32A:110501USD117,00
:50K:/101606502953
LEILA MATAKHERIA
:52D://FW221272316
HUDSON CITY SAVINGS BANK FSB
:59:/GE94BR0000000036119005
Shalva Ozbetelashvili
:70:900161245
:71A:SHA
-}")]
        [InlineData(
            "//RU044525550.30101810145250000550",
            @"AO KB muNISTRIMm
MOSKVA",
            @"{1:F01UGEBGE22AXXX1097443006}{2:O1030806160408BYLADEMMAXXX30754883591604081006N}{3:{108:ZVP6932802/1}}{4:
:20:PMI100804158
:23B:CRED
:32A:160730USD1000000,
:33B:USD1000000,
:50K:/30111810000000000133
INN9909375490
AKCIONERNOE OBqESTVO mPROGRESS BANK
m
:52D://RU044525550.30101810145250000550
AO KB muNISTRIMm
MOSKVA
:59:INN0000011263
AO mBANK GRUZIIm, G.TBILISI
:70:'(VO60070)'POPOLNENIE KORScETA 'GE1
8BG0000000545117400 PROGRESS BANK U
L BARATAQVILI 8 TBILISI GRUZIa 'BEZ
NDS.
:71A:SHA
:71F:RUB0,
:72:/RPP/93.160729.5.ELEK.01
/DAS/160729.160729.000000.000000
-}")]
        [InlineData(
            null,
            @"AUSTRALIA AND NEW ZEALAND BANKING
570 CHURCH STREET
RICHMOND VIC AUSTRALIA 3121 -",
            @"{1:F01REPLGE22AXXX3200376358}{2:O1031650120323BKTRUS33AXXX08753227021203240901N}{3:{108:S355495ICP032312}}{4:
:20:S355495ICP032312
:23B:CRED
:32A:120323USD2025,00
:50K:/013247553551371
TCHEUPDJIAN K AND A
3 HASTINGS RD
:52D:AUSTRALIA AND NEW ZEALAND BANKING
570 CHURCH STREET
RICHMOND VIC AUSTRALIA 3121 -
:59:/GE90BR0000010787181104
ARTUR MINASYAN
(ARMINTOUR)
:70:/RFB/NONEN
:71A:SHA
:72:/BNF/OUR REF JPM120320-004803CHASER
//EF7160400080FCFIELD :33B: USD2075
//,00
-}")]
        public void TestOptionD(string expPartyIdentifier, string expNameAndAdress, string actMT103Message)
        {
            var mt103Message = new MT103(
                new ParsedSwiftMessage(
                    new Mandator<string>(actMT103Message)
                ).Content().First()
            );
            Assert.Equal(
                expPartyIdentifier,
                new OrderingInstitution_52a(
                    mt103Message.OrderingInstitution_52A.Value,
                    mt103Message.OrderingInstitution_52D.Value
                ).OptionD.PartyIdentifier
            );

            Assert.Equal(
                new SplitedByLines(expNameAndAdress).Value(),
                new OrderingInstitution_52a(
                    mt103Message.OrderingInstitution_52A.Value,
                    mt103Message.OrderingInstitution_52D.Value
                ).OptionD.NameAndAdress
            );
        }
    }
}