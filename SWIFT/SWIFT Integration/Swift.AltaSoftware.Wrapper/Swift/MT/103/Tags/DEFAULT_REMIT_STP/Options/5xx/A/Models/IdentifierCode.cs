using System;
using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A.Models
{
    public class IdentifierCode
    {
        private readonly string _tag52AValue;

        public IdentifierCode(string tag52AValue)
        {
            _tag52AValue = tag52AValue;
        }

        public string Value()
        {
            var splitedTagValue = new SplitedByLines(_tag52AValue).Value();
            var result = String.Empty;
            if (splitedTagValue.Length != 1)
            {
                result = splitedTagValue[1];
            }
            else
            {
                result = splitedTagValue[0];
            }
            return result;
        }
    }
}