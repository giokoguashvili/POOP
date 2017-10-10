using System;
using System.Linq;
using Swift.AltaSoftware.Wrapper.DataSourceForTests;
using Swift.Infrastructure.Infrastructure;
using SWIFTFramework.Messages.Category1;
using Xunit;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_DEFAULT
{
    public class AsMT103Tests
    {
        [Theory]
        [TextFileDataSource(@"SWIFT_IN.txt")]
        public void Method(string swiftFileContent)
        {
            foreach (var swiftMessage in new RawSwiftMessages(new SwiftFile(swiftFileContent)))
            {
                try
                {
                    var mt =
                        new AsMT103_DEFAULT(
                            new MT103(
                                new ValidatedSwiftMessage(
                                        new ParsedSwiftMessage(swiftMessage),
                                        new MT103ValidationRules()
                                    ).Content()
                                    .First()
                            )
                        );
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(mt);
                    Console.WriteLine($"Parsed SwiftMessage: {json}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error parse this SwiftMessage: {swiftMessage}, {e}");
                    throw;
                }

            }
        }
    }
}