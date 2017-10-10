using System;
using Nest;
using PeopleSearch.Web.Api.Infrastructure;

namespace PeopleSearch.Web.Api.Domain.Interfaces
{
    public interface IElasticQuery<Type> : IContent<Func<SearchDescriptor<Type>, ISearchRequest>>
        where Type : class
    { }
}
