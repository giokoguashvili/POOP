using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Web.Api.Domain
{
    
    public class Batches<Type> : IEnumerable<IEnumerable<Type>>
    {
        private readonly IEnumerable<Type> _data;
        private readonly int _batchSize;

        public Batches(IEnumerable<Type> data, int batchSize)
        {
            _data = data;
            _batchSize = batchSize;
        }
        public IEnumerator<IEnumerable<Type>> GetEnumerator()
        {
            return Enumerable
                .Range(0, _data.Count() / _batchSize + 1)
                .Aggregate(
                    new List<IEnumerable<Type>>(),
                    (acc, index) => acc
                        .Concat(
                            new List<IEnumerable<Type>>()
                            {
                                _data
                                    .Skip(index * _batchSize)
                                    .Take(_batchSize)
                            }
                        ).ToList()
                ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
