using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._23E
{
	public class InstructionCode_23ETests
	{
		[Theory]
		[InlineData("TELI", "/3226553478", "TELI/3226553478")]
		[InlineData("CHQB", "", "CHQB")]
        public void Method(string expInstruction, string expAdditionalInformation, string tag23EValue)
	    {
	        Assert.Equal(
	            expInstruction,
						new InstructionCode_23E(tag23EValue).Instruction
					);

	        Assert.Equal(
	            expAdditionalInformation,
	            new InstructionCode_23E(tag23EValue).AdditionalInformation
	        );
        }
	}
}