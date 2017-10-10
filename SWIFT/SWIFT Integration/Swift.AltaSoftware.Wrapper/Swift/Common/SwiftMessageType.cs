using System;
using Swift.Infrastructure.Infrastructure;
using SWIFTFramework;

namespace Swift.AltaSoftware.Wrapper.Swift.Common
{
    public class SwiftMessageType 
    {
        private readonly SwiftMessage _swiftMessage;

        public SwiftMessageType(SwiftMessage swiftMessage)
        {
            _swiftMessage = swiftMessage;
        }

        public bool Is(IContent<string> mtTagName)
        {
            return Content().Contains(mtTagName.Content());
        }
        public string Content()
        {
            if (_swiftMessage.MessageType == "103")
            {
                SwiftBlock3 block3_2 = _swiftMessage.Block3;
                if (block3_2 != null)
                {
                    SwiftTag tagByName = block3_2.GetTagByName("119");
                    if (tagByName != null && tagByName.Value == "STP")
                        return "MT103STP";
                    if (tagByName != null && tagByName.Value == "REMIT")
                        return "MT103REMIT";
                }
            }
            return String.Format(
                "MT{0}",
                _swiftMessage.MessageType
            );
        }
    }
}
