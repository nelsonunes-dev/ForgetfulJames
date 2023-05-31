using ForgetfulJames.Business.Abstractions.Services;
using ForgetfulJames.Domain.Options;
using ForgetfulJames.Infrastructure.Abstractions;
using Microsoft.Extensions.Options;

namespace ForgetfulJames.Business.Services
{
    public class InitialiseInfrastructureService : IInitialiseInfrastructureService
    {
        private readonly IInitialiseDatabase _initialiseDatabase;
        private readonly InfrastructureOptions _infrastructureOptions;
        private readonly ISeedDatabase _seedDatabase;

        public InitialiseInfrastructureService(IInitialiseDatabase initialiseDatabase, IOptions<InfrastructureOptions> infrastructureOptions, ISeedDatabase seedDatabase) 
        {
            _initialiseDatabase = initialiseDatabase;
            _infrastructureOptions = infrastructureOptions.Value;
            _seedDatabase = seedDatabase;
        }

        public async Task InitialiseDatabaseAsync(CancellationToken cancellationToken = default)
        {
            if (_infrastructureOptions.RunMigrations)
                await _initialiseDatabase.InitialiseDatabaseAsync(cancellationToken);
        }

        public async Task SeedDatabaseAsync(CancellationToken cancellationToken = default)
        {
            if (_infrastructureOptions.SeedDatabase)
            {
                if (_infrastructureOptions.UseMockData)
                    await SeedDatabaseAsync(_infrastructureOptions.UseMockData, cancellationToken);
                else
                    await _seedDatabase.SeedDatabaseAsync(cancellationToken);
            }
        }

        public async Task SeedDatabaseAsync(bool useMockData, CancellationToken cancellationToken = default)
        {
            await _seedDatabase.SeedDatabaseAsync(useMockData, cancellationToken);
        }
    }
}
