using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_STP.Tags._55A
{
    public class ThirdReimbursementInstitution_55A
    {
        public ThirdReimbursementInstitution_55A(string tag55AValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                tag55AValue,
                t => new OptionA(t)
            ).Value();
        }

        public OptionA OptionA { get; }

    }
}
