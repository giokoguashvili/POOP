using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;
using SWIFTFramework;

namespace Swift.AltaSoftware.Wrapper.Swift.Common
{
    public class SwiftMessageBank 
    {
        private readonly SwiftMessage _swiftMessage;

        public SwiftMessageBank(SwiftMessage swiftMessage)
        {
            _swiftMessage = swiftMessage;
        }

        public bool Is(IContent<string> bank)
        {
            return _swiftMessage.Block1.LTAddress.Contains(bank.Content());
        }
    }
}
