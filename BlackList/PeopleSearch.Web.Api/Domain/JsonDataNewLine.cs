using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleSearch.Web.Api.Infrastructure;

namespace PeopleSearch.Web.Api.Domain
{
    public class JsonDataNewLine : IContent<string>
    {
        public string Content()
        {
            return "\n";
        }
    }
}
