using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using PeopleSearch.Web.Api.Domain.Interfaces;
using PeopleSearch.Web.Api.Models;

namespace PeopleSearch.Web.Api.Domain
{
    public class PersonsByFuzzyName : IEnumerable<Person>
    {
        private readonly ElasticClient _elasticClient;
        private readonly IElasticQuery<Person> _elasticQuery;

        public PersonsByFuzzyName(
                ElasticClient elasticClient,
                string fuzzyName
            )
            : this(
                  elasticClient, 
                  new PersonFuzzyQueryByName(fuzzyName)
              )
        {

        }

        public PersonsByFuzzyName(
                ElasticClient elasticClient,
                IElasticQuery<Person> elasticQuery
            )
        {
            _elasticClient = elasticClient;
            _elasticQuery = elasticQuery;
        }
        public IEnumerator<Person> GetEnumerator()
        {
            return _elasticClient
                .Search(
                    _elasticQuery
                        .Content()
                )
                .Documents
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
