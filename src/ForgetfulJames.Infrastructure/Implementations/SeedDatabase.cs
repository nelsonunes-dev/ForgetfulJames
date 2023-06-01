using ForgetfulJames.Infrastructure.Abstractions;
using ForgetfulJames.Infrastructure.Seeding;

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
            await new ToDoSeeding().Seed(_dbContext, useMockData, cancellationToken);
        }
    }
}
