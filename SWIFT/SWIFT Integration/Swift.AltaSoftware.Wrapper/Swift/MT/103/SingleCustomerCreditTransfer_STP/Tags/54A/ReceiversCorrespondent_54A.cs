using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_STP.Tags._54A
{
    public class ReceiversCorrespondent_54A
    {
        public ReceiversCorrespondent_54A(string tag54AValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                tag54AValue,
                t => new OptionA(t)
            ).Value();
        }

        public OptionA OptionA { get; }

    }
}
