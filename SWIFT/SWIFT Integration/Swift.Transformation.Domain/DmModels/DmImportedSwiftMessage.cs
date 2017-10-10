using System;
using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._20;
using Swift.Infrastructure.Infrastructure;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using Swift.Integration.Db.Models;
using SWIFTFramework;

namespace Swift.Integration.Domain.DmModels
{
    public class DmImportedSwiftMessage : IDbModel<DbImportedMessage>
    {
        private readonly string _swiftFileName;
        private readonly string _b6UserId;
        private readonly IMandatory<string> _rawSwiftMessage;
        public DmImportedSwiftMessage(string sendersReference, string connectionString)
            : this(new DbImportedMessage(sendersReference, connectionString))
        {}

        public DmImportedSwiftMessage(string sendersReference, OpenedSqlConnection openedSqlConnection)
            : this(new DbImportedMessage(sendersReference, openedSqlConnection))
        { }

        public DmImportedSwiftMessage(DbImportedMessage dbImportedMessage)
            : this(dbImportedMessage.SwiftFileName, dbImportedMessage, dbImportedMessage.B6UserId)
        {}
        public DmImportedSwiftMessage(
            string swiftFileName,
            string swiftMessage,
            string b6UserId
        )
            : this(swiftFileName, new Mandator<string>(swiftMessage), b6UserId)
        { }
        public DmImportedSwiftMessage(
                string swiftFileName,
                IContent<DbImportedMessage> swiftMessage,
                string b6UserId
            )
            : this(swiftFileName, new LazyMandator<string>(() => swiftMessage.Content().RawContent), b6UserId)
        {}
        public DmImportedSwiftMessage(
                string swiftFileName,
                IMandatory<string> swiftMessage,
                string b6UserId
            )
        {
            _swiftFileName = swiftFileName;
            _rawSwiftMessage = swiftMessage;
            _b6UserId = b6UserId;
        }

        public AsSwiftMessage AsSwiftMessage()
        {
            return new AsSwiftMessage(
                        new ParsedSwiftMessage(
                            _rawSwiftMessage
                        )
                    ); 
        }

        public SwiftMessage SwiftMessage()
        {
            return new ParsedSwiftMessage(
                        _rawSwiftMessage
                    ).Fold();
        }

        public DbImportedMessage AsDbModel()
        {
            var swiftMessage = new ParsedSwiftMessage(_rawSwiftMessage).Fold();
            return new DbImportedMessage(
                new SenderReference_20(swiftMessage).Value,
                _swiftFileName,
                new SwiftMessageType(swiftMessage).Content(),
                _rawSwiftMessage.Fold(),
                swiftMessage.Block1.LTAddress,
                _b6UserId,
                DateTime.UtcNow,
                null
            );
        }
    }
}
