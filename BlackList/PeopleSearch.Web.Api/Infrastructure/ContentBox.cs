using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Web.Api.Infrastructure
{
    public class ContentBox<T> : IContent<T>
    {
        private readonly T _data;

        public ContentBox(T data)
        {
            _data = data;
        }
        public T Content()
        {
            return _data;
        }
    }
}
