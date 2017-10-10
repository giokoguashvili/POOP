using Swift.AltaSoftware.Wrapper.Swift.MT;
using Swift.Infrastructure.Infrastructure.Box;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using SWIFTFramework;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public class ValidatedBlock1 : IPipe<SwiftMessage, IValidationRules>
    {
        private readonly IMandatory<SwiftMessage> _swiftMessage;
        public ValidatedBlock1(IMandatory<SwiftMessage> swiftMessage)
        {
            _swiftMessage = swiftMessage;
        }
        public IOptional<SwiftMessage> Pipe(IValidationRules rules)
        {
            return new Mapped<SwiftMessage, SwiftMessage>(
                    _swiftMessage,
                    message => new BlockWithValidationRules(message, rules).WithBlock1ValidationRules()
                );
        }
    }
}