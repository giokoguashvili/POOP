using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions.Mapper;

namespace Swift.Integration.Db.Models
{
    public class CustomPluralizedMapper<T> : PluralizedAutoClassMapper<T> where T : class
    {
        public override void Table(string tableName)
        {
            SchemaName = "SWIFT";
            base.Table("Temp");
            AutoMap();
        }
    }
}
