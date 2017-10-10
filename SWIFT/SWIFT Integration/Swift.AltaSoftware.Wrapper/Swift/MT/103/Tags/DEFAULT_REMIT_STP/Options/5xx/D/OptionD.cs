using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A.Models;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.D.Models;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.D
{
    public class OptionD
    {
        public OptionD(string tag52DValue)
        {
            PartyIdentifier = new NullIfEmpty<string>(
                                    new PartyIdentifier(tag52DValue).Value(),
                                    t => t
                              ).Value();
            NameAndAdress = new NameAndAdress(
                                new CuttedWithFirstFountTag(tag52DValue, PartyIdentifier).Value()
                            ).Value();
        }

        public string PartyIdentifier { get; }
        public string[] NameAndAdress { get; }
    }
}