using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.D.Models
{
    public class NameAndAdress
    {
        private readonly string _tag52DValue;

        public NameAndAdress(string tag52DValue)
        {
            _tag52DValue = tag52DValue;
        }

        public string[] Value()
        {
            return new SplitedByLines(_tag52DValue).Value();
        }
    }
}