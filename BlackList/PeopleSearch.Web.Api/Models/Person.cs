using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Web.Api.Models
{
    public class Identifier
    {
        public string number { get; set; }
        public string type { get; set; }
    }

    public class Nationality
    {
        public string country { get; set; }
        public string country_code { get; set; }
    }

    public class BirthDate
    {
        public string date { get; set; }
        public string quality { get; set; }
    }

    public class Person
    {
        public string source { get; set; }
        public List<Identifier> identifiers { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public string second_name { get; set; }
        public string function { get; set; }
        public List<Nationality> nationalities { get; set; }
        public string first_name { get; set; }
        public string id { get; set; }
        public string timestamp { get; set; }
        public List<BirthDate> birth_dates { get; set; }
        public string listed_at { get; set; }
        public string type { get; set; }
        public string program { get; set; }
    }
}
