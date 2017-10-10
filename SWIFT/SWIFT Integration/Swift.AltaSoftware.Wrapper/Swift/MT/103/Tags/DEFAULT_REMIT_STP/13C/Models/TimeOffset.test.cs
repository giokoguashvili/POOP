using Xunit;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._13C.Models
{
    public class TimeOffsetTests
    {
        [Fact]
        public void MethodHH()
        {
            Assert.Equal(
                    "01",
                    new TimeOffset("/CLSTIME/0915+0100").HH
                );
        }

        [Fact]
        public void MethodMM()
        {
            Assert.Equal(
                "00",
                new TimeOffset("/CLSTIME/0915+0100").MM
            );
        }
    }
}