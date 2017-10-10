using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PeopleSearch.Web.Api.Infrastructure;

namespace PeopleSearch.Web.Api.Domain
{
    public interface ILines : IEnumerable<string> { }
    public class Lines : ILines
    {
        private readonly IContent<string> _jsonFile;

        public Lines(IEnumerable<string> strs)
            : this(new ContentBox<string>(String.Join(new JsonDataNewLine().Content(), strs)))
        {
            
        }
        public Lines(string str)
            : this(new ContentBox<string>(str))
        {}

        public Lines(IContent<string> jsonFile)
        {
            _jsonFile = jsonFile;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _jsonFile
                .Content()
                .Split(
                    new JsonDataNewLine().Content(), 
                    StringSplitOptions.RemoveEmptyEntries
                 )
                .ToList()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
