using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._13C.Models
{
    public class SignTests
    {
        [Fact]
        public void Method()
        {
            Assert.Equal(
                    "+",
                    new Sign("/CLSTIME/0915+0100").Value()
                );
        }
    }
}