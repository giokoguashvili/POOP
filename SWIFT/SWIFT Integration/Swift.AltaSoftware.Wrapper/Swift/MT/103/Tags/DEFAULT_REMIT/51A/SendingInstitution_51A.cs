using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._51A
{
    public class SendingInstitution_51A
    {
        public SendingInstitution_51A(string tag51AValue)
        {
            OptionA = new OptionA(tag51AValue);
        }

        public OptionA OptionA { get; }

    }
}