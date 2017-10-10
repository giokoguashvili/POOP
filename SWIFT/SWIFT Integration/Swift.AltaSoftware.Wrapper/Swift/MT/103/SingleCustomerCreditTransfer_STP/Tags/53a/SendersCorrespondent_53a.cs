using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.B;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_STP.Tags._53a
{
    public class SendersCorrespondent_53a
    {

        public SendersCorrespondent_53a(string tag53AValue, string tag53BValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                            tag53AValue,
                            t => new OptionA(t)
                       ).Value();
            OptionB = new NullIfEmpty<OptionB>(
                            tag53BValue,
                            t => new OptionB(t)
                        ).Value();
        }

        public OptionA OptionA { get;  }
        public OptionB OptionB { get;  }
    }
}