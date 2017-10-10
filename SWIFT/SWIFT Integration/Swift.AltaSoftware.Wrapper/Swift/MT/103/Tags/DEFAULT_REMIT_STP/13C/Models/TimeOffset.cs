using System;
using System.Linq;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._13C.Models
{
    /// <summary>
    /// /8c/4!n1!x4!n
    /// </summary>
    public class TimeOffset
    {
        public TimeOffset(string tag13CValue)
        {
            HH = String.Join(
                "",
                tag13CValue
                    .Split('/')[2]
                    .Skip(5)
                    .Take(2)
            );

            MM = String.Join(
                "",
                tag13CValue
                    .Split('/')[2]
                    .Skip(7)
                    .Take(2)
            );
        }

        public string HH { get;  }

        public string MM { get; }
    };
}