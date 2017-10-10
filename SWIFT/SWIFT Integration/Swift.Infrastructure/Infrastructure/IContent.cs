namespace Swift.Infrastructure.Infrastructure
{
    public interface IContent<out TResult>
    {
        TResult Content();
    }
}
