using System;

namespace Swift.AltaSoftware.Wrapper.Swift.Common.Validators
{
    public class RangeValidator
    {
        public RangeValidator(string str, int minLen, int maxLen)
        {
            if (str.Length < minLen || str.Length > maxLen)
                throw new Exception("");
        }
    }
}