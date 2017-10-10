using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_STP.Tags._52A
{
    public class OrderingInstitution_52A
    {
        public OrderingInstitution_52A(string tag52AValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                tag52AValue,
                t => new OptionA(t)
            ).Value();
        }

        public OptionA OptionA { get; }
    }
}