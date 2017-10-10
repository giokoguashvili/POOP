using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.D.Models;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.A.Models;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._59a.Options
{
    public class NoLetterOption
    {
        public NoLetterOption(string tagValue)
        {
            Account = new NullIfEmpty<string>(
                            new Account(tagValue).Value(),
                            t => t
                      ).Value();
            NameAndAdress = new NameAndAdress(
                                new CuttedWithFirstFountTag(
                                    tagValue,
                                    Account
                                ).Value()
                            ).Value();
              
        }

        public string Account { get; }
        public string[] NameAndAdress { get; }
    }
}
