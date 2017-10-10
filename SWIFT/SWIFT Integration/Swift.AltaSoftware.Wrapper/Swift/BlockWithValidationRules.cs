using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift.MT;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using SWIFTFramework;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public class BlockWithValidationRules
    {
        private readonly IMandatory<SwiftMessage> _swiftMessage;
        private readonly IValidationRules _blockValidationRules;

        public BlockWithValidationRules(IMandatory<SwiftMessage> swiftMessage, IValidationRules blockValidationRules)
        {

            _swiftMessage = swiftMessage;
            _blockValidationRules = blockValidationRules;
        }

        public SwiftMessage WithBlock1ValidationRules()
        {
            var swiftMessage = _swiftMessage.First();
            swiftMessage.Block1.Rules.AddRange(_blockValidationRules.Block1Rules());
            return swiftMessage;
        }

        public SwiftMessage WithBlock2ValidationRules()
        {
            var swiftMessage = _swiftMessage.First();
            swiftMessage.Block2.Rules.AddRange(_blockValidationRules.Block2Rules());
            return swiftMessage;
        }
    }
}