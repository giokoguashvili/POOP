using DapperExtensions.Mapper;

namespace Swift.Integration.Db.Models
{
    public sealed class DbImportedMessageMapper : ClassMapper<DbImportedMessage>
    {
        public DbImportedMessageMapper()
        {
            base.Schema("SWIFT");
            base.Table("ImportedMessages");
            AutoMap();
        }
    }


}
