using System;
using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A.Models
{
    public class PartyIdentifier
    {
        private readonly string _tag52AValue;

        public PartyIdentifier(string tag52AValue)
        {
            _tag52AValue = tag52AValue;
        }

        public string Value()
        {
            if (_tag52AValue.Contains("/"))
            {
                return new SplitedByLines(_tag52AValue).Value()[0];
            }
            return String.Empty;
        }
    }
}