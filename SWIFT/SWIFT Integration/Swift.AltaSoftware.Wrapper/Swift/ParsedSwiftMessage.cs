using System.Collections.Generic;
using Swift.Infrastructure.Infrastructure.Box.Abstract;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using SWIFTFramework;
using SWIFTFramework.Validation;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public class ParsedSwiftMessage : Mandatory<SwiftMessage>
    {
        private readonly IMandatory<string> _rawSwiftMessage;

        public ParsedSwiftMessage(string rawSwiftMessage)
            : this(new Mandator<string>(rawSwiftMessage))
        {}
        public ParsedSwiftMessage(IMandatory<string> rawSwiftMessage)
        {
            _rawSwiftMessage = rawSwiftMessage;
        }


        public override IMandatory<SwiftMessage> Content()
        {
            var parseErrors = new List<ValidationError>();
            var parsedSwiftMessage = SwiftParser
                .Instance
                .GetMessage(
                    _rawSwiftMessage
                        .Fold(),
                    parseErrors
                );
            return new Mandator<SwiftMessage>(
                        parsedSwiftMessage
                   );
        }
    }
}