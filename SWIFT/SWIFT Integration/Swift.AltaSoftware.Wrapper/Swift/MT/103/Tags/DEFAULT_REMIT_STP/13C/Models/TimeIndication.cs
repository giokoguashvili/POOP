using System;
using System.Linq;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._13C.Models
{
    /// <summary>
    /// /8c/4!n1!x4!n - (Code)(Time indication)(Sign)(Time offset)
    /// </summary>
    public class TimeIndication
    {
        private readonly string _tag13CValue;

        public TimeIndication(string tag13CValue)
        {
            _tag13CValue = tag13CValue;
        }

        public string Value()
        {
            return String.Join(
                        "",
                        _tag13CValue
                            .Split('/')[2]
                            .Take(4)
                   );
        }
    }
}