namespace PeopleSearch.Web.Api.Infrastructure
{
    public interface IContent<out TResult>
    {
        TResult Content();
    }
}
