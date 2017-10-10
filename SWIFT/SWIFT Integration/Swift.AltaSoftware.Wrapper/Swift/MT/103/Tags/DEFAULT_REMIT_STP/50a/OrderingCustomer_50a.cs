using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.F;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a.Options.K;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a
{
    public class OrderingCustomer_50a
    {

        public OrderingCustomer_50a(string tag50AValue, string tag50FValue, string tag50KValue)
        {
            OptionA = new NullIfEmpty<OptionA>(
                            tag50AValue,
                            t => new OptionA(t)
                        ).Value();
            OptionF = new NullIfEmpty<OptionF>(
                            tag50FValue,
                            t => new OptionF(t)
                        ).Value();
            OptionK = new NullIfEmpty<OptionK>(
                            tag50KValue,
                            t => new OptionK(t)
                        ).Value();
        }

        public OptionA OptionA { get; }
        public OptionF OptionF { get; }
        public OptionK OptionK { get; }
    }
}