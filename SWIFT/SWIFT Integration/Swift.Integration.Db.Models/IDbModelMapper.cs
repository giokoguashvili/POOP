using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions.Mapper;

namespace Swift.Integration.Db.Models
{
    public class IDbModelMapper : ClassMapper<IDbModel>
    {
        public IDbModelMapper()
        {
            DapperExstensionsExstensions.CorrespondingTypeMapper<IDbModel>((tableName, schemaName, exprs) =>
            {
                Table(tableName);
                Schema(schemaName);
                return exprs.Select(Map);
            }).ToList();
        }
    }
}
