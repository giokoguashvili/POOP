using Swift.AltaSoftware.Wrapper.Swift.MT;
using Swift.Infrastructure.Infrastructure.Box.Abstract;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using SWIFTFramework;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public class ValidatedSwiftMessage : Optional<SwiftMessage>
    {
        private readonly IMandatory<SwiftMessage> _swiftMessage;
        private readonly IValidationRules _mtMessageValidationRules;

        public ValidatedSwiftMessage(IMandatory<SwiftMessage> swiftMessage, IValidationRules mtMessageValidationRules)
        {
            _swiftMessage = swiftMessage;
            _mtMessageValidationRules = mtMessageValidationRules;
        }
        public override IOptional<SwiftMessage> Content()
        {
            return new ValidatedBlock2(
                        new ValidatedBlock1(
                            _swiftMessage
                        )
                    ).Pipe(_mtMessageValidationRules);
        }
    }
}