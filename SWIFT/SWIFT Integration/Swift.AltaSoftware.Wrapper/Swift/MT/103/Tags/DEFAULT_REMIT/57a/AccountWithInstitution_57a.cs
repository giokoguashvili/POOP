using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.B;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.C;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.D;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._57a
{
    public class AccountWithInstitution_57a
    {
        public AccountWithInstitution_57a(string tag57AValue, string tag57BValue, string tag57CValue, string tag57DValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                tag57AValue,
                t => new OptionA(t)
            ).Value();
            OptionB = new NullIfEmpty<OptionB>(
                tag57BValue,
                t => new OptionB(t)
            ).Value();
            OptionC = new NullIfEmpty<OptionC>(
                tag57CValue,
                t => new OptionC(t)
            ).Value();
            OptionD = new NullIfEmpty<OptionD>(
                tag57DValue,
                t => new OptionD(t)
            ).Value();
        }

        public OptionA OptionA { get; }
        public OptionB OptionB { get; }
        public OptionC OptionC { get; }
        public OptionD OptionD { get; }
    }
}
