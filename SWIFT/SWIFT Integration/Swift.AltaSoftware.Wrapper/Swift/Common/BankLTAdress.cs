using Swift.Infrastructure.Infrastructure;
using SWIFTFramework;

namespace Swift.AltaSoftware.Wrapper.Swift.Common
{
   public  class BankLTAdress : IContent<string>
    {
        private readonly SwiftMessage _swiftMessage;

        public BankLTAdress(SwiftMessage swiftMessage)
        {
            _swiftMessage = swiftMessage;
        }
        public string Content()
        {
            return _swiftMessage.Block1.LTAddress;
        }
    }

    public class BankLTAdressDefault : IContent<string>
    {
        public string Content()
        {
            return "*";
        }
    }
}
