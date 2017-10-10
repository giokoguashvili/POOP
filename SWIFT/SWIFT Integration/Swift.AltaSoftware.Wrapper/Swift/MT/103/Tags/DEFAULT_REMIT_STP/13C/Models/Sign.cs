using System;
using System.Linq;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._13C.Models
{
    public class Sign
    {
        private readonly string _tag13CValue;

        public Sign(string tag13CValue)
        {
            _tag13CValue = tag13CValue;
        }

        public string Value()
        {
            return String.Join(
                "",
                _tag13CValue
                    .Split('/')[2]
                    .Skip(4)
                    .Take(1)
            );
        }
    }
}