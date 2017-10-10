using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleSearch.Web.Api.Infrastructure;
using PeopleSearch.Web.Api.Models;

namespace PeopleSearch.Web.Api.Domain
{
    public class PersonCheckResult
    {
        private readonly IEnumerable<Person> _persons;

        public PersonCheckResult(IEnumerable<Person> persons)
        {
            _persons = persons;
        }

        public bool Exist => _persons.Any();
    }
}
