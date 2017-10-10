using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.C;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.D;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_STP.Tags._56A
{
    public class IntermediaryInstitution_56A
    {
        public IntermediaryInstitution_56A(string tag56AValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                tag56AValue,
                t => new OptionA(t)
            ).Value();
        }

        public OptionA OptionA { get; }
        public OptionC OptionC { get; }
        public OptionD OptionD { get; }

    }
}
