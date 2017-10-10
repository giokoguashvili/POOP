using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.B;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.D;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._55a
{
    public class ThirdReimbursementInstitution_55a
    {
        public ThirdReimbursementInstitution_55a(string tag55AValue, string tag55BValue, string tag55DValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                tag55AValue,
                t => new OptionA(t)
            ).Value();
            OptionB = new NullIfEmpty<OptionB>(
                tag55BValue,
                t => new OptionB(t)
            ).Value();
            OptionD = new NullIfEmpty<OptionD>(
                tag55DValue,
                t => new OptionD(t)
            ).Value();
        }

        public OptionA OptionA { get; }
        public OptionB OptionB { get; }
        public OptionD OptionD { get; }

    }
}
