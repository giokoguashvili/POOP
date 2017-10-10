using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._59a.Options;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._59a
{
    public class BeneficiaryCustomer_59a
    {
        public BeneficiaryCustomer_59a(string tag59Value, string tag59AValue, string tag59FValue)
        {
            NoLetterOption = new NullIfEmpty<NoLetterOption>(
                                tag59Value,
                                t => new NoLetterOption(t)
                            ).Value();
            OptionA = new NullIfEmpty<OptionA>(
                            tag59AValue,
                            t => new OptionA(t)
                        ).Value();
            OptionF = new NullIfEmpty<OptionF>(
                            tag59FValue,
                            t => new OptionF(t)
                        ).Value();
        }

        public NoLetterOption NoLetterOption { get; }
        public OptionA OptionA { get; }
        public OptionF OptionF { get; }
    }
}
