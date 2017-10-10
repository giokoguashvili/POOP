namespace Swift.Infrastructure.Infrastructure.Box.Interfaces
{
    public interface IPipe<TOutput, in TInput>
    {
        IOptional<TOutput> Pipe(TInput param);
    }
}