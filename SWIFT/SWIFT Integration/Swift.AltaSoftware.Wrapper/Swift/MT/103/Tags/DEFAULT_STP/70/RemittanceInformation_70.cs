using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_STP._70
{
    public class RemittanceInformation_70
    {
        private readonly string _tag70Value;

        public RemittanceInformation_70(string tag70Value)
        {
            Narrative = new SplitedByLines(tag70Value).Value();
        }

        public string[] Narrative { get; }
    }
}
