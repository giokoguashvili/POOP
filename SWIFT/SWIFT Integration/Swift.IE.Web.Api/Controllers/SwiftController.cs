using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using System.Xml;
using MT103.Transformation.Rule;
using Newtonsoft.Json;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.AltaSoftware.Wrapper.Swift.MT._103;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_DEFAULT;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Contracts.MT103;
using Swift.Transformation.Rules.Engine;
using Swift.Transformation.Rules.Engine.MEF;
using Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig;
using Swift.Transformation.Rules.Engine.RulesMap.TransformationRulesMap;
using SWIFTFramework;
using SWIFTFramework.Messages.Category1;

namespace Swift.IE.Web.Api.Controllers
{
    public class SwiftController : ApiController
    {
        public AsMT103_DEFAULT Post(AltaSoftware.Wrapper.Swift.SwiftFile swiftFile)
        {
            //var @path =
            //    @"C:\Users\g.koguashvili.ALTASOFT\Source\Workspaces\SWIFT Integration\SWIFT Integration\Swift.Transformation.Rules.Engine\bin\Debug\1";
           // var parts = new AttributedParts<ITransformationRule>(@path)
             //   .Content();
            //var ruleInfo = new RuleInfo(parts.First().Metadata);

            //var swiftSection = new FlatedSwiftConfig(
            //        new SwiftConfigSection("swiftSection")
            //    )
            //    .Content();
            //swiftSection
            //    .TransformationRules
            //    .OfType<TransformationRuleElement>()
            //    .Select(tre => tre.)

            //var t = new MT103_DEFAULT_Rule(null).GetType();
            //var tt = new MT103_DEFAULT_RuleImpl().GetType();
            var mt =
                new SWIFTFramework.Messages.Category1.MT103(
                    new ValidatedSwiftMessage(
                        new ParsedSwiftMessage(
                            new RawSwiftMessages(
                                swiftFile
                            ).First()
                        ),
                        new MT103ValidationRules()
                    ).Content()
                    .First()
                );
            var result = new AsMT103_DEFAULT(mt);
            return result;

            //return new JsonSwiftMessage(mt).Content();
        }

        //[HttpPost]
        //public string JSON(RawSwiftFile swiftFile)
        //{
        //    var mt =
        //        new MT103(
        //            new ValidatedSwiftMessage(
        //                    new ParsedSwiftMessage(
        //                        new RawSwiftMessages(
        //                            swiftFile
        //                        ).First()
        //                    ),
        //                    new MT103ValidationRules()
        //                ).Content()
        //                .First()
        //        );
        //    return new JsonSwiftMessage(mt).Content();
        //}
    }
}
