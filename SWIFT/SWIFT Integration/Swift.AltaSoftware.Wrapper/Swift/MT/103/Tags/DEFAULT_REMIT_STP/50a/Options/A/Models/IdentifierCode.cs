using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.A.Models
{
    /// <summary>
    /// [/34x]
    /// 4!a2!a2!c[3!c]
    /// </summary>
    public class IdentifierCode
    {
        private readonly string _tag50ATag;

        public IdentifierCode(string tag50ATag)
        {
            _tag50ATag = tag50ATag;
        }

        public string Value()
        {
            var splitedTag = new SplitedByLines(_tag50ATag).Value();
            if (_tag50ATag.StartsWith("/"))
                return splitedTag[1];
            return splitedTag[0];
        }
    }
}