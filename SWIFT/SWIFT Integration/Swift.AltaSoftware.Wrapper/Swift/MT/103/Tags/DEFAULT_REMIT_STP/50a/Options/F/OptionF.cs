using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.F.Models;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.F
{
    public class OptionF
    {
        public OptionF(string tag50FValue)
        {
            PartyIdentifier = new PartyIdentifier(tag50FValue).Value();
            NameAndAdress = new NameAndAdress(
                                new CuttedWithFirstFountTag(tag50FValue, PartyIdentifier).Value()
                            ).Value();
        }

        public string PartyIdentifier { get;  }
        public string[] NameAndAdress { get;  }
    }
}