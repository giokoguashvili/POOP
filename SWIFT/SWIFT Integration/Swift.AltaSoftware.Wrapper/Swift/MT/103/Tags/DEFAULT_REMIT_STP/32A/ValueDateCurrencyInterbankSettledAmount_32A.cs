using System;
using System.Globalization;
using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._32A
{
    /// <summary>
    /// 6!n3!a15d
    /// </summary>
    public class ValueDateCurrencyInterbankSettledAmount_32A
    {
        public ValueDateCurrencyInterbankSettledAmount_32A(string tag32AValue)
        {
            Date = DateTime.ParseExact(
                tag32AValue.Substring(0, 6),
                "yyMMdd",
                CultureInfo.InvariantCulture
            );
            Currency = tag32AValue.Substring(6, 3);
            Amount = new SwiftAmount(tag32AValue.Substring(9)).Value();
        }

        public DateTime Date { get; }

        //public DateTime Date => new SwiftDateTime(_tag32AValue.Substring(0, 6)).Value();
        public string Currency { get; }

        public decimal Amount { get;  }
    }
}