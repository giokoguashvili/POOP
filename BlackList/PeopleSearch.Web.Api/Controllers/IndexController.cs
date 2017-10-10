using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Nest;
using PeopleSearch.Web.Api.Domain;
using PeopleSearch.Web.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using PeopleSearch.Web.Api.Models;


namespace PeopleSearch.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class IndexController : Controller
    {
        private readonly ElasticClient _elasticClient;

        public IndexController(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        [HttpGet("{secret}")]
        public ActionResult Get(string secret)
        {
            if (secret.Equals("qwerty"))
            {
                return 
                    new JsonResult(
                        new ExecutedCommand(
                            new IndexCommand<Person>(
                                _elasticClient,
                                new ValidatedJsons(
                                    new Lines(
                                        new JsonFile(@"./Data/master.json")
                                    )
                                )
                            )
                        )
                    );
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
