using System;
using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.B.Models
{
    public class Location
    {
        private readonly string _optionBTagValue;

        public Location(string optionBTagValue)
        {
            _optionBTagValue = optionBTagValue;
        }

        public string Value()
        {
            var splitedTagValue = new SplitedByLines(_optionBTagValue).Value();

            if (splitedTagValue.Length == 1 && splitedTagValue[0].Contains("/"))
            {
                return String.Empty;
            }

            if (splitedTagValue.Length == 1 && !splitedTagValue[0].Contains("/"))
            {
                return splitedTagValue[0];
            }

            if (splitedTagValue.Length == 2)
            {
                return splitedTagValue[1];
            }
            return String.Empty;
        }
    }
}