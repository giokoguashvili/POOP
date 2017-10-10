using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;
using Swift.Transformation.Rules.Engine.Views;
using Swift.Transformation.Rules.Engine.Views.MtRule;
using Swift.Transformation.Rules.Engine.Views.SwiftConfig;

namespace Swift.Transformation.Rules.Engine.RulesMap.SwiftConfig
{
    public class VerifiedFlatedSwiftConfig : IContent<IEnumerable<SwiftConfigItem>>
    {
        private readonly IContent<IEnumerable<SwiftConfigItem>> _flatedSwiftConfig;

        public VerifiedFlatedSwiftConfig(IContent<IEnumerable<SwiftConfigItem>> flatedSwiftConfig)
        {
            _flatedSwiftConfig = flatedSwiftConfig;
        }

        public IEnumerable<SwiftConfigItem> Content()
        {
            var verifiedConfig = _flatedSwiftConfig
                .Content()
                .GroupBy(fsc => new
                    {
                        BankLTAdress = fsc.BankLTAdress().Content(),
                        ImplementationKey = fsc.ImplementationKey().Content()
                    },
                    item => item
                )
                .Select(g =>
                {
                    if (g.Count() > 2)
                    {
                        return new Option<SwiftConfigItem>(
                                    g.First().View()
                                );
                    }
                    else
                    {
                        return new Option<SwiftConfigItem>(g.First());
                    }
                })
                .ToArray();


            if (verifiedConfig.All(mtr => mtr.Fold(some: rule => true, nothing: m => false)))
            {
                return verifiedConfig
                    .SelectMany(vc => vc);
            }
            throw new Exception(
                new FaildValidatedRulesView(
                    verifiedConfig
                        .Where(mtr => mtr.Fold(some: rule => false, nothing: m => true))
                        .SelectMany(mtr => mtr.Match(some: (a) => new ViewBox(""), nothing: (m) => new ViewBox(m)))
                ).View()
            );
        }


    }
}
