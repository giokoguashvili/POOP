using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions.Mapper;

namespace Swift.Integration.Db.Models
{
    public sealed class DbDOCS_IN_SWIFTMapper : ClassMapper<DbDOCS_IN_SWIFT>
    {
        public DbDOCS_IN_SWIFTMapper()
        {
            base.Schema("impexp");
            base.Table("DOCS_IN_SWIFT");
            AutoMap();
        }
    }
}
