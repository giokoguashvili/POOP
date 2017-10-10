using System;
using System.Globalization;

namespace Swift.AltaSoftware.Wrapper.Swift.Common
{
    public class SwiftAmount
    {
        private readonly string _amountValue;

        private readonly NumberFormatInfo _formatInfo = new NumberFormatInfo
        {
            NegativeSign = "-",
            CurrencyDecimalSeparator = ","
        };

        public SwiftAmount(string amountValue)
        {
            _amountValue = amountValue;
        }

        public decimal Value()
        {
            return Decimal.Parse(_amountValue, NumberStyles.Currency, _formatInfo);
        }
    }
}