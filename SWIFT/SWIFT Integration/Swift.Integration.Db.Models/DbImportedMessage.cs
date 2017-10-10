using System;
using System.Linq;
using DapperExtensions;
using Swift.Infrastructure.Infrastructure;

namespace Swift.Integration.Db.Models
{
    public class DbImportedMessage : IContent<DbImportedMessage>, IDbModel
    {
        private readonly Lazy<DbImportedMessage> _dbImportedMessage;
        public string SendersReference{ get; set; }
        public string SwiftFileName{ get; set; }
        public string Type{ get; set; }
        public string RawContent { get; set; }
        public string SenderBankName{ get; set; }
        public string B6UserId{ get; set; }
        public DateTime ImportDateTime{ get; set; }
        public DateTime? UploadDateTime{ get; set; }
        public DbImportedMessage()
        {}
        public DbImportedMessage(
                string sendersReference,
                string swiftFileName,
                string type,
                string content,
                string senderBankName,
                string b6UserId,
                DateTime importDateTime,
                DateTime? uploadDateTime 
            )
        {
            SendersReference = sendersReference;
            SwiftFileName = swiftFileName;
            Type = type;
            RawContent = content;
            SenderBankName = senderBankName;
            B6UserId = b6UserId;
            ImportDateTime = importDateTime;
            UploadDateTime = uploadDateTime;
            _dbImportedMessage = new Lazy<DbImportedMessage>(() => this);
        }
        private DbImportedMessage(DbImportedMessage dbImportedMessage)
            : this(
                    dbImportedMessage.SenderBankName,
                    dbImportedMessage.SwiftFileName,
                    dbImportedMessage.Type,
                    dbImportedMessage.RawContent,
                    dbImportedMessage.SenderBankName,
                    dbImportedMessage.B6UserId,
                    dbImportedMessage.ImportDateTime,
                    dbImportedMessage.UploadDateTime
                  )
        {}
        public DbImportedMessage(string sendersReference, OpenedSqlConnection openedSqlConnection)
        {
            _dbImportedMessage = new Lazy<DbImportedMessage>(
                                    () => openedSqlConnection
                                                    .Value()
                                                    .GetList<DbImportedMessage>(
                                                            Predicates.Field<DbImportedMessage>(f => f.SendersReference, Operator.Eq, sendersReference)
                                                     )
                                                    .First()
                                 );
        }
        public DbImportedMessage(string sendersReference, string connectionStriong)
            : this(sendersReference, new OpenedSqlConnection(connectionStriong))
        { }
        public DbImportedMessage Content()
        {
            return _dbImportedMessage != null ? new DbImportedMessage(_dbImportedMessage.Value ?? this) : new DbImportedMessage(this);
        }
    }
}
