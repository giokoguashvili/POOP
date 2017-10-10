using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PeopleSearch.Web.Api.Infrastructure;

namespace PeopleSearch.Web.Api.Domain
{
    public class ElasticPostCommands : IEnumerable<string>
    {
        private readonly IContent<ILines> _lines;

        public ElasticPostCommands()
        {
        }

        public ElasticPostCommands(IContent<ILines> lines)
        {
            _lines = lines;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return _lines
                .Content()
                .Select(l => new ElasticPostCommand(l).Content())
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
