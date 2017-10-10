namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._23E
{
    public class InstructionCode_23E
    {

        public InstructionCode_23E(string tag23EValue)
        {
            Instruction = tag23EValue.Substring(0, 4);
            AdditionalInformation = tag23EValue.Substring(4);
        }

        public string Instruction { get; }
        public string AdditionalInformation { get; } 
    }
}