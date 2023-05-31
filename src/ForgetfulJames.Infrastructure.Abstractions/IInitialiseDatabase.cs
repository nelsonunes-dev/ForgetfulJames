namespace ForgetfulJames.Infrastructure.Abstractions
{
    public interface IInitialiseDatabase
    {
        Task InitialiseDatabaseAsync(CancellationToken cancellationToken = default);
    }
}