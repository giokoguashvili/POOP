namespace Swift.Infrastructure.Infrastructure.Box.Interfaces
{
    public interface IMandatory<out T> : IBox<T>
    {
        T Fold();
    }
}
