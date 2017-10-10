using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.B;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.D;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._54a
{
    public class ReceiversCorrespondent_54a
    {
        public ReceiversCorrespondent_54a(string tag54AValue, string tag5BAValue, string tag54DValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                tag54AValue,
                t => new OptionA(t)
            ).Value();
            OptionB = new NullIfEmpty<OptionB>(
                tag5BAValue,
                t => new OptionB(t)
            ).Value();
            OptionD = new NullIfEmpty<OptionD>(
                tag54DValue,
                t => new OptionD(t)
            ).Value();
        }

        public OptionA OptionA { get; }
        public OptionB OptionB { get; }
        public OptionD OptionD { get; }

    }
}
