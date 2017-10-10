using System;
using System.Linq;

namespace Swift.AltaSoftware.Wrapper.Swift.Common
{
    public class CuttedWithFirstFountTag
    {
        private readonly string _source;
        private readonly string _tag;

        public CuttedWithFirstFountTag(string source, string tag)
        {
            _source = source;
            _tag = tag ?? String.Empty;
        }

        public string Value()
        {
            return String.Join(String.Empty,_source.Skip(_tag.Length));
        }
    }
}