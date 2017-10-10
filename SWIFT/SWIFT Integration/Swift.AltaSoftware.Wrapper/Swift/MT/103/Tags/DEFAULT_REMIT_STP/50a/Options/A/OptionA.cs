using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.A.Models;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.A
{
    public class OptionA
    {
        public OptionA(string tag50AValue)
        {
            Account = new NullIfEmpty<string>(
                            new Account(tag50AValue).Value(),
                            x => x
                      ).Value();
            IdentifierCode = new IdentifierCode(tag50AValue).Value();
        }

        public string Account { get; }
        public string IdentifierCode { get; }
    }
}