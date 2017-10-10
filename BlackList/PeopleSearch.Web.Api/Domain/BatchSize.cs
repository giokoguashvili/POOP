using PeopleSearch.Web.Api.Infrastructure;

namespace PeopleSearch.Web.Api.Domain
{
    public class BatchSize : IContent<int>
    {
        private readonly int _batchSize;
        public BatchSize(int batchSize)
        {
            _batchSize = batchSize;
        }

        public int Content()
        {
            return _batchSize;
        }
    }
}