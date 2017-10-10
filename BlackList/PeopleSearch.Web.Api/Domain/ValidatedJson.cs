using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PeopleSearch.Web.Api.Infrastructure;

namespace PeopleSearch.Web.Api.Domain
{
    public class ValidatedJson : IEnumerable<string>
    {
        private readonly string _rawJson;

        public ValidatedJson(string rawJson)
        {
            _rawJson = rawJson;
        }
        public IEnumerator<string> GetEnumerator()
        {
            try
            {
                var tmpObj = JsonConvert.DeserializeObject(_rawJson);
                return new List<string>() { _rawJson }.GetEnumerator();
            }
            catch (FormatException fex)
            {
                //Invalid json format
                Debug.WriteLine(fex);
                return new List<string>().GetEnumerator();
            }
            catch (Exception ex) //some other exception
            {
                Debug.WriteLine(ex.ToString());
                return new List<string>().GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
