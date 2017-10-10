using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._72
{
    public class SenterToReceiverInformation_72
    {
        public SenterToReceiverInformation_72(string tag72Value)
        {
            Narrative = new SplitedByLines(tag72Value).Value();
        }
        public string[] Narrative { get; }
    }
}
