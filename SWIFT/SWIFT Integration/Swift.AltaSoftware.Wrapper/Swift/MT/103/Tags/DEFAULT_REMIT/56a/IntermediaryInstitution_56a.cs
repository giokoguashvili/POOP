using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.C;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.D;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._56a
{
    public class IntermediaryInstitution_56a
    {
        public IntermediaryInstitution_56a(string tag56AValue, string tag56CValue, string tag56DValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                tag56AValue,
                t => new OptionA(t)
            ).Value();
            OptionC = new NullIfEmpty<OptionC>(
                tag56AValue,
                t => new OptionC(t)
            ).Value();
            OptionD = new NullIfEmpty<OptionD>(
                tag56AValue,
                t => new OptionD(t)
            ).Value();
        }

        public OptionA OptionA { get; }
        public OptionC OptionC { get; }
        public OptionD OptionD { get; }

    }
}
