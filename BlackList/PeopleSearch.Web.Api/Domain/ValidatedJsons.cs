using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleSearch.Web.Api.Infrastructure;

namespace PeopleSearch.Web.Api.Domain
{
    public class ValidatedJsons : IContent<ILines>
    {
        private readonly IEnumerable<string> _strs;

        public ValidatedJsons(IEnumerable<string> strs)
        {
            _strs = strs;
        }
        public ILines Content()
        {
            return new Lines(
                    String
                        .Join(
                            new JsonDataNewLine().Content(),
                            _strs
                                .SelectMany(l => new ValidatedJson(l))
                                .ToArray()
                        )
                );
        }
    }
}
