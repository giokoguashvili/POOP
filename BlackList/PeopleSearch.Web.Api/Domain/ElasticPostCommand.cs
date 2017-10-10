using System;
using PeopleSearch.Web.Api.Infrastructure;

namespace PeopleSearch.Web.Api.Domain
{
    public class ElasticPostCommand : IContent<string>
    {
        private readonly string _data;
        private readonly string _commandFormat = "{{ \"index\": {{}} }}{1}{0}";
        public ElasticPostCommand(string data)
        {
            _data = data;
        }
        public string Content()
        {
            return String.Format(_commandFormat, _data, Environment.NewLine);
        }
    }
}