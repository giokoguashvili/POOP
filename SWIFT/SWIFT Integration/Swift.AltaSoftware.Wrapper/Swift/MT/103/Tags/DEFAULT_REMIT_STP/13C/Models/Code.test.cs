using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._13C.Models
{
    public class CodeTests
    {
        [Fact]
        public void Method()
        {
            Assert.Equal(
                    "8c",
                    new Code("/8c/4!n1!x4!n").Value()
                );
        }
    }
}