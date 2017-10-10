using Nest;
using PeopleSearch.Web.Api.Infrastructure;
using PeopleSearch.Web.Api.Models;
using System;
using PeopleSearch.Web.Api.Domain.Interfaces;

namespace PeopleSearch.Web.Api.Domain
{


    public class PersonFuzzyQueryByName : IElasticQuery<Person>
    {
        private readonly string _searchValue;

        public PersonFuzzyQueryByName(string searchValue)
        {
            _searchValue = searchValue;
        }
        public Func<SearchDescriptor<Person>, ISearchRequest> Content()
        {
            /////
            // https://www.elastic.co/blog/found-fuzzy-search
            // match query + fuzziness option: Adding the fuzziness parameter to a match query turns a plain match query into a fuzzy one. 
            // Analyzes the query text before performing the search.
            //
            //return s => s.Query(q => q.Fuzzy(f => f.Field(fi => fi.name).Value(_searchValue)));
            /////
            return s => s
                    .Query(q => q
                                .Match(m => m
                                            .Field(f => f.name)
                                            .Query(_searchValue)
                                            .Fuzziness(Fuzziness.EditDistance(3))
                                            .PrefixLength(0)
                                            .Operator(Operator.And)
											//https://www.elastic.co/guide/en/elasticsearch/guide/current/fuzzy-query.html
											.MaxExpansions(3)
                                            .MinimumShouldMatch(new MinimumShouldMatch("70%"))
                                )
                     );
        }
    }
}
