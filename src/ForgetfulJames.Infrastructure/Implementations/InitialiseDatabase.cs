using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ForgetfulJames.Infrastructure.Abstractions;

namespace ForgetfulJames.Infrastructure.Implementations
{
    public class InitialiseDatabase : IInitialiseDatabase
    {
        private readonly ApplicationDbContext _dbContext;

        public InitialiseDatabase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitialiseDatabaseAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbContext.Database.MigrateAsync(cancellationToken).WaitAsync(cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken).WaitAsync(cancellationToken);
            }
            catch (SqlException ex)
            {

            }
        }
    }
}
