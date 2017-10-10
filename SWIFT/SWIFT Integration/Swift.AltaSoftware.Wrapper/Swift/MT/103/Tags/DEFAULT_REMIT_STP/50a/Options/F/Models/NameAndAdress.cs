using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.F.Models
{
    public class NameAndAdress
    {
        private readonly string _tag50FValue;

        public NameAndAdress(string tag50FValue)
        {
            _tag50FValue = tag50FValue;
        }

        public string[] Value()
        {
            return new SplitedByLines(_tag50FValue).Value();
        }
    }
}