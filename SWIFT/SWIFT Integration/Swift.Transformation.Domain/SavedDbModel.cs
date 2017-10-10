using System;
using Dapper;
using DapperExtensions;
using Swift.Infrastructure.Infrastructure;
using Swift.Integration.Db.Models;


namespace Swift.Integration.Domain
{
    public class SaveDbModelCommand : ICommand<string>
    {
        private readonly IDbModel<IDbModel> _dbModel;
        private readonly OpenedSqlConnection _openedSqlConnection;


        public SaveDbModelCommand(IDbModel<IDbModel> dbModel, OpenedSqlConnection openedSqlConnection)
        {
            _dbModel = dbModel;
            _openedSqlConnection = openedSqlConnection;
        }

        public string Execute()
        {
            try
            {
                _openedSqlConnection
                    .Value()
                    .Insert(_dbModel.AsDbModel());
                return "Inserted";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
