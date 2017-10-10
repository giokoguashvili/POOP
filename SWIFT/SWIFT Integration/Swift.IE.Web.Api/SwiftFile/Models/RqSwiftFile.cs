using System.Collections.Generic;
using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.Integration.Db.Models;
using Swift.Integration.Domain.DmModels;

namespace Swift.IE.Web.Api.SwiftFile.Models
{
    public class RqSwiftFile
    {
        public string B6UserId { get; set; }
        public string Name { get; set; }
        public string Content { private get; set; }
        public IEnumerable<IDbModel<DbImportedMessage>> AsDmImportedSwiftMessage()
        {
            return new RawSwiftMessages(
                        new AltaSoftware.Wrapper.Swift.SwiftFile(Content)
                    )
                    .Select(
                        rsm => new DmImportedSwiftMessage(
                                    Name,
                                    rsm,
                                    B6UserId
                               )
                    );
        }
    }
}