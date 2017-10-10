using Swift.AltaSoftware.Wrapper.Swift.MT;
using Swift.Infrastructure.Infrastructure.Box;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using SWIFTFramework;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public class ValidatedBlock2 : IPipe<SwiftMessage, IValidationRules>
    {
        private readonly IPipe<SwiftMessage, IValidationRules> _swiftMessagePipe;
        public ValidatedBlock2(IPipe<SwiftMessage, IValidationRules> swiftMessagePipe)
        {
            _swiftMessagePipe = swiftMessagePipe;
        }
        public IOptional<SwiftMessage> Pipe(IValidationRules param)
        {
            return new Mapped<SwiftMessage, SwiftMessage>(
                _swiftMessagePipe.Pipe(param),
                message => new BlockWithValidationRules(message, param).WithBlock2ValidationRules()
            );
        }
    }
}