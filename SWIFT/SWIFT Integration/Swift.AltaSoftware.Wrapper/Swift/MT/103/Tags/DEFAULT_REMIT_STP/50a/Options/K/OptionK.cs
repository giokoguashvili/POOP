using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.A.Models;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.F.Models;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.K
{
    public class OptionK
    {
        public OptionK(string tag50KValue)
        {
            Account = new NullIfEmpty<string>(new Account(tag50KValue).Value(), x => x).Value();
            NameAndAdress = new NameAndAdress(
                                    new CuttedWithFirstFountTag(tag50KValue, Account).Value()
                            ).Value();
        }
        public string Account { get; }
        public string[] NameAndAdress { get; }
    }
}