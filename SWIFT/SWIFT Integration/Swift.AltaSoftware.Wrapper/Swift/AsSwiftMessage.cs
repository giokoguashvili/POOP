using System.Collections.Generic;
using SWIFTFramework;
using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_DEFAULT;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_REMIT;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_STP;
using Swift.Infrastructure.Infrastructure;
using Swift.Infrastructure.Infrastructure.Box;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using SWIFTFramework.Messages.Category1;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public class AsSwiftMessage : IContent<IOptional<IAsSwiftMessage>>
    {
        private readonly IMandatory<SwiftMessage> _parsedSwiftMessage;

        public AsSwiftMessage(IMandatory<string> rawSwiftMessage)
            : this(new ParsedSwiftMessage(rawSwiftMessage))
        {}
        public AsSwiftMessage(string rawSwiftMessage)
            : this(new ParsedSwiftMessage(rawSwiftMessage))
        { }
        public AsSwiftMessage(IMandatory<SwiftMessage> parsedSwiftMessage)
        {
            _parsedSwiftMessage = parsedSwiftMessage;
        }

        //public IOptional<SwiftMessage> MT103_REMIT()
        //{
        //    return AsMT(new MT103_REMIT_Type());
        //}

        //public IOptional<SwiftMessage> MT103_STP()
        //{
        //    return AsMT(new MT103_STP_Type());
        //}

        //public IOptional<SwiftMessage> MT103_DEFAULT()
        //{
        //    return AsMT(new MT103_DEFAULT_Type());
        //}

        //public IOptional<SwiftMessage> MT103_REMIT()
        //{
        //    return AsMT(new MT103_REMIT_Type());
        //}

        //public IOptional<SwiftMessage> MT103_STP()
        //{
        //    return AsMT(new MT103_STP_Type());
        //}
        public IOptional<IAsSwiftMessage> Content()
        {
            return new Option<IAsSwiftMessage>(
                       new List<IAsSwiftMessage>()
                            .Concat(MT103_REMIT())
                            .Concat(MT103_DEFAULT())
                            .Concat(MT103_STP())
                   );
        }

        public IOptional<AsMT103_DEFAULT> MT103_DEFAULT()
        {
            return new Option<AsMT103_DEFAULT>(
                _parsedSwiftMessage
                    .Where(sm => new SwiftMessageType(sm).Is(new MT103_DEFAULT_Type()))
                    .Select(sm => new AsMT103_DEFAULT(sm))
            );
        }

        public IOptional<AsMT103_REMIT> MT103_REMIT()
        {
            return new Option<AsMT103_REMIT>(
                _parsedSwiftMessage
                    .Where(sm => new SwiftMessageType(sm).Is(new MT103_REMIT_Type()))
                    .Select(sm => new AsMT103_REMIT(sm))
            );
        }

        public IOptional<AsMT103_STP> MT103_STP()
        {
            return new Option<AsMT103_STP>(
                _parsedSwiftMessage
                    .Where(sm => new SwiftMessageType(sm).Is(new MT103_STP_Type()))
                    .Select(sm => new AsMT103_STP(sm))
            );
        }
        private IOptional<SwiftMessage> AsMT(IContent<string> tagName)
        {
            return new Option<SwiftMessage>(
                _parsedSwiftMessage
                    .Where(sm => new SwiftMessageType(sm).Is(tagName))
            );
        }
    }
}
