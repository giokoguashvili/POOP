using System;
using System.Data.SqlClient;

namespace Swift.Integration.Db.Models
{
    public class OpenedSqlConnection : IDisposable
    {
        private readonly SqlConnection _sqlConnection;
        public OpenedSqlConnection(string connectionStringName)
            : this(new SqlConnection(connectionStringName))
        {
        }
        public OpenedSqlConnection(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
            _sqlConnection.Open();
        }

        public SqlConnection Value()
        {
            DapperExtensions
                .DapperExtensions
                .SetMappingAssemblies(
                    new[]
                    {
                        typeof(DbImportedMessageMapper).Assembly,
                        typeof(DbDOCS_IN_SWIFTMapper).Assembly,
                        typeof(IDbModelMapper).Assembly
                    }
                );
          
            return _sqlConnection;
        }

        public void Dispose()
        {
            _sqlConnection?.Dispose();
        }
    }
}
