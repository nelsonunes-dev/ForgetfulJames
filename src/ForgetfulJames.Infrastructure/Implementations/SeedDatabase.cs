using ForgetfulJames.Infrastructure.Abstractions;

namespace ForgetfulJames.Infrastructure.Implementations
{
    public class SeedDatabase : ISeedDatabase
    {
        private readonly ApplicationDbContext _dbContext;

        public SeedDatabase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedDatabaseAsync(CancellationToken cancellationToken = default)
        {
            await SeedDatabaseAsync(false, cancellationToken);
        }

        public async Task SeedDatabaseAsync(bool useMockData, CancellationToken cancellationToken = default)
        {
        }
    }
}
