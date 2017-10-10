namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._13C.Models
{
    public class Code
    {
        private readonly string _tag13CValue;

        public Code(string tag13CValue)
        {
            _tag13CValue = tag13CValue;
        }

        public string Value()
        {
            return _tag13CValue.Split('/')[1];
        }
    }
}