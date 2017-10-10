using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A.Models;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A
{
    public class OptionA
    {
        public OptionA(string tag52AValue)
        {
            PartyIdentifier = new NullIfEmpty<string>(
                                    new PartyIdentifier(tag52AValue).Value(),
                                    t => t
                            ).Value();
            IdentifierCode = new IdentifierCode(tag52AValue).Value();
        }
        public string PartyIdentifier { get; }
        public string IdentifierCode { get;  }
    }
}