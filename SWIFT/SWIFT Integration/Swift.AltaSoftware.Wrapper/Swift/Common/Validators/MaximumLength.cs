using System;

namespace Swift.AltaSoftware.Wrapper.Swift.Common.Validators
{
    public class MaximumLength
    {
        private readonly string _str;
        private readonly int _maxLen;

        public MaximumLength(string str, int maxLen)
        {
            _str = str;
            _maxLen = maxLen;
        }

        public string Validated()
        {
            if (_str.Length > _maxLen) 
                throw new Exception($"Maximum Length is: {_maxLen}, {_str} length is: {_str.Length}");
            return _str;
        }
    }
}