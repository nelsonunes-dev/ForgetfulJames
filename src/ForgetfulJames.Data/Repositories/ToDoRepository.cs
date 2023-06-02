using ForgetfulJames.Data.Abstractions.Repositories;
using ForgetfulJames.Data.Common;
using ForgetfulJames.Domain.Entities;
using ForgetfulJames.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ForgetfulJames.Data.Repositories
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        protected DbSet<ToDo> _dbSet;
        private readonly ILogger<ToDo> _logger; 
        
        public ToDoRepository(ApplicationDbContext dbContext, ILogger<ToDo> logger) : base(dbContext, logger) 
        { 
            _dbSet = dbContext.Set<ToDo>();
            _logger = logger;
        }

        public async Task<IEnumerable<ToDo>> GetByUserIdAsync(string id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.Where(x => x.UserId == id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("{nameOf} threw an exception of {ex} with a message of {message}", nameof(GetByUserIdAsync), ex, ex.Message);
            }

            return Enumerable.Empty<ToDo>();
        }
    }
}
