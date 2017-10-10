using System;
using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.A.Models
{
    public class Account
    {
        private readonly string _tag50AValue;

        public Account(string tag50AValue)
        {
            _tag50AValue = tag50AValue;
        }

        public string Value()
        {
            if (_tag50AValue.StartsWith("/"))
                return new SplitedByLines(_tag50AValue).Value()[0];
            return String.Empty;
        }
    }
}