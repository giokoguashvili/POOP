using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.F.Models
{
    public class PartyIdentifier
    {
        private readonly string _tag50AValue;

        public PartyIdentifier(string tag50AValue)
        {
            _tag50AValue = tag50AValue;
        }

        public string Value()
        {
            return new SplitedByLines(_tag50AValue).Value()[0];
        }
    }
}