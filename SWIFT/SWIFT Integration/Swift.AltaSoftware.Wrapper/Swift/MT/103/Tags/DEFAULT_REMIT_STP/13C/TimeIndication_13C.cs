using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._13C.Models;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._13C
{
    /// <summary>
    /// /8c/4!n1!x4!n
    /// </summary>
    public class TimeIndication_13C
    {
        public TimeIndication_13C(string tag13CValue)
        {
            Code = new Code(tag13CValue).Value();
            TimeIndication = new TimeIndication(tag13CValue).Value();
            Sign = new Sign(tag13CValue).Value();
            TimeOffset = new TimeOffset(tag13CValue);
        }

        public string Code { get; }
        public string TimeIndication { get; }
        public string Sign { get; }
        public TimeOffset TimeOffset { get;  }
    }
}