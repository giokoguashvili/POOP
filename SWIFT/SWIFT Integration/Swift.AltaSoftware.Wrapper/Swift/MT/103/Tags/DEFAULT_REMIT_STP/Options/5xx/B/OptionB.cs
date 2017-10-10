using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A.Models;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.B.Models;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.B
{
    public class OptionB
    {
        public OptionB(string tagValue)
        {
            PartyIdentifier = new NullIfEmpty<string>(
                                    new PartyIdentifier(tagValue).Value(),
                                    t => t
                                ).Value();

            Location = new NullIfEmpty<string>(
                            new Location(tagValue).Value(),
                            t => t
                       ).Value();
        }

        public string PartyIdentifier { get; }
        public string Location { get; set; }
    }
}