namespace ForgetfulJames.Infrastructure.Abstractions
{
    public interface ISeedDatabase
    {
        Task SeedDatabaseAsync(CancellationToken cancellationToken = default);
        Task SeedDatabaseAsync(bool useMockData, CancellationToken cancellationToken = default);
    }
}
