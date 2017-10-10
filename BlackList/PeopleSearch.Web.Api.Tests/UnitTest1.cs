using System;
using Nest;
using PeopleSearch.Web.Api.Domain;
using PeopleSearch.Web.Api.Models;
using Xunit;

namespace PeopleSearch.Web.Api.Tests
{
    public class UnitTest1
    {
		private readonly ElasticClient _elasticClient;
	    public UnitTest1()
	    {
			_elasticClient = new ElasticClient(
								new ConnectionSettings(
									new Uri("http://elasticsearch:9200")
								).DefaultIndex("people")
							);
			//new IndexCommand<Person>(
			//	new ElasticClient(
			//		new ConnectionSettings(
			//			new Uri("http://elasticsearch:9200")
			//		).DefaultIndex("people_test")
			//	),
			//	new ValidatedJsons(
			//		new Lines(
			//			new JsonFile(@"./Data/master.json")
			//		)
			//	)
			//).Execute();
		}

		[Fact]
        public void Test1()
		{
			Assert
				.True(
					new PersonCheckResult(
						new PersonsByFuzzyName(
							_elasticClient,
							"giorgadze"
						)
					).Exist
				);
		}
    }
}
