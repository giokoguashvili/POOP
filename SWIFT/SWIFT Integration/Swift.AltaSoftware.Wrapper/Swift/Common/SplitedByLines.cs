using System;

namespace Swift.AltaSoftware.Wrapper.Swift.Common
{
    public class SplitedByLines
    {
        private readonly string _str;

        public SplitedByLines(string str)
        {
            _str = str;
        }

        public string[] Value()
        {
            return _str.Split(new[] {"\n", "\n\r", "\r"}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}