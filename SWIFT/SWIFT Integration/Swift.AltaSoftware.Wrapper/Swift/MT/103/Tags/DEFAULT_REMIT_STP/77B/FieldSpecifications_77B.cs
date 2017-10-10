using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._77B
{
    public class FieldSpecifications_77B
    {
        public FieldSpecifications_77B(string tag77BValue)
        {
            Narrative = new SplitedByLines(tag77BValue).Value();
        }
        public string[] Narrative { get; }
    }
}
