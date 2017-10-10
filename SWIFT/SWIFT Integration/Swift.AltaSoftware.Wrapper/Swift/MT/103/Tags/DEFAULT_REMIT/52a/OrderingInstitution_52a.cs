using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP.Options._5xx.D;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._52a
{
    public class OrderingInstitution_52a
    {
        public OrderingInstitution_52a(string tag52AValue, string tag52DValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                            tag52AValue,
                            t => new OptionA(t)
                      ).Value();
                
            OptionD = new NullIfEmpty<OptionD>(
                            tag52DValue,
                            t => new OptionD(t)
                        ).Value(); 
        }

        public OptionA OptionA { get; }
        public OptionD OptionD { get; }
    }
}