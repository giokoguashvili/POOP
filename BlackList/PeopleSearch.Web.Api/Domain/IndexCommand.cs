using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Elasticsearch.Net;
using Nest;
using Newtonsoft.Json;
using PeopleSearch.Web.Api.Infrastructure;
using PeopleSearch.Web.Api.Models;

namespace PeopleSearch.Web.Api.Domain
{
    public interface ICommand
    {
        void Execute(); 
    }
    public class IndexCommand<Type> : ICommand
        where Type : class
    {
        private readonly ElasticClient _elasticClient;
        private readonly IContent<ILines> _lines;
        public IndexCommand(
                ElasticClient elasticClient,
                IContent<ILines> lines
            )
        {
            _elasticClient = elasticClient;
            _lines = lines;
        }

        public void Execute()
        {
            var waitHandle = new CountdownEvent(1);
            _elasticClient
                .BulkAll(
                    _lines
                        .Content()
                        .Select(JsonConvert.DeserializeObject<Type>), 
                    b => b
                        .BackOffRetries(2)
                        .BackOffTime("30s")
                        .RefreshOnCompleted(true)
                        .MaxDegreeOfParallelism(4)
                        .Size(1000)
            )
            .Subscribe(
                new BulkAllObserver(
                    onNext: (b) => { Debug.Write("OK"); },
                    onError: (e) => { throw e; },
                    onCompleted: () => waitHandle.Signal()
                )
            );
            waitHandle.Wait();


            //var indexResponse = _elasticClient
            //    .LowLevel
            //    .Bulk<VoidResponse>(
            //        _index,
            //        _type,
            //        _postData
            //    );
            //if (!indexResponse.Success)
            //    throw new Exception(indexResponse.DebugInformation);
        }
    }
}
