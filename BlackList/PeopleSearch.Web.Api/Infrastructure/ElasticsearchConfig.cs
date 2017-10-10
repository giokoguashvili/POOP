using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Web.Api.Infrastructure
{
    public class ElasticsearchConfig
    {
        public string Uri { get; set; }
        public string Index { get; set; }
        public string Type { get; set; }
    }
}
