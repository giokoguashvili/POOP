using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using Swift.IE.Web.Api.SwiftFile.Models;
using Swift.Infrastructure.Infrastructure;
using Swift.Integration.Db.Models;
using Swift.Integration.Domain;
using Swift.Integration.Domain.DmModels;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Engine.AltaSoftware;
using Swift.Transformation.Rules.Engine.MEF;
using Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig;
using Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap;
using Swift.Transformation.Rules.Engine.Store;

namespace Swift.IE.Web.Api.SwiftFile
{
    public class SwiftFileController : ApiController
    {
        private readonly string _connectionString;
        private readonly ITransformationRulesStore _transformationRulesStore;

        public SwiftFileController()
            : this(
                  "BANK2000ConnectionString",
                  @"C:\Users\g.koguashvili.ALTASOFT\Source\Workspaces\SWIFT Integration\SWIFT Integration\MT103.Transformation.Rule\1",
                  "swiftSection"
              )
        {}

        public SwiftFileController(
                string connectionStringName,
                string dllsPath,
                string swiftConfigSectionName
            )
            : this(
                       connectionStringName,
                       dllsPath,
                       new FlatedSwiftConfig(
                           new SwiftConfigSection(swiftConfigSectionName)
                       )
                 )
        {
            
        }
        public SwiftFileController(
                string connectionStringName, 
                string dllsPath,
                IContent<IEnumerable<SwiftConfigItem>> flatedSwiftConfig
            )
            : this(
                ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString,
                new TransformationRulesStore(
                    new AsTransformationRules(
                        flatedSwiftConfig,
                        new AttributedParts<ITransformationRule>(dllsPath)
                    ).Content()
                )
              )
        { }
        public SwiftFileController(string connectionString, ITransformationRulesStore transformationRulesStore)
        {
            _connectionString = connectionString;
            _transformationRulesStore = transformationRulesStore;
        }

        public void Post(RqSwiftFile swiftFile)
        {
            using (var openedSqlConnection = new OpenedSqlConnection(_connectionString))
            {
                swiftFile
                    .AsDmImportedSwiftMessage()
                    .Select(dmSm =>
                                new SaveDbModelCommand(
                                    dmSm,
                                    openedSqlConnection
                                ).Execute()
                     ).ToList();


                var bankSenderRef = "D0343380243401";
                new DmImportedSwiftMessage(
                    new DbImportedMessage(bankSenderRef, openedSqlConnection)
                )
                .AsSwiftMessage()
                .Content()
                .Select(sm =>
                        new SaveDbModelCommand(
                            new TransformedSwiftMessage(
                                sm,
                                _transformationRulesStore
                            ),
                            openedSqlConnection
                        ).Execute()
                ).ToList();

                //object obj = new DbTemp() {Title = "gio" + new Random().Next() };
                //openedSqlConnection.Value().Insert(obj);
                //openedSqlConnection.Value().Insert(obj);
                //var gio = 0;
            }
        }
    }
}
