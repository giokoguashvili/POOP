using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using PeopleSearch.Web.Api.Domain;

namespace PeopleSearch.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        private readonly ElasticClient _elasticClient;

        public CheckController(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        [HttpGet("{name}")]
        public PersonCheckResult Get(string name)
        {
            return new PersonCheckResult(
                        new PersonsByFuzzyName(
                            _elasticClient, 
                            name
                        )
                    );
        }
    }
}