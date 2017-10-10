using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_STP.Tags._57A
{
    public class AccountWithInstitution_57A
    {
        public AccountWithInstitution_57A(string tag57AValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                tag57AValue,
                t => new OptionA(t)
            ).Value();
        }

        public OptionA OptionA { get; }
    }
}
