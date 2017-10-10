using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using Nest;
using PeopleSearch.Web.Api.Domain;
using PeopleSearch.Web.Api.Models;

namespace PeopleSearch.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ElasticClient _elasticClient;

        public SearchController(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _elasticClient
                        .Search<Person>(s => s
                            .Query(q => q
                                .MatchAll()
                            )
                        )
                        .Documents
                        .ToList(); 
        }

        [HttpGet("{name}")]
        public IEnumerable<Person> Get(string name)
        {
            return new PersonsByFuzzyName(
                        _elasticClient,
                        name
                    );
        }
    }
}