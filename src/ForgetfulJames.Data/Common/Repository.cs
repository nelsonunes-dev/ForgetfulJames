using ForgetfulJames.Data.Abstractions.Common;
using ForgetfulJames.Dto.Response;
using ForgetfulJames.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ForgetfulJames.Data.Common
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _dbContext;
        protected DbSet<T> _dbSet;
        private readonly ILogger<T> _logger;

        public Repository(ApplicationDbContext dbContext, ILogger<T> logger)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _logger = logger;
        }

        public async Task<ResponseDto> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var response = new ResponseDto();

            try
            {
                await _dbSet.AddAsync(entity, cancellationToken);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError("{nameOf} threw an exception of {ex} with a message of {message}", nameof(AddAsync), ex, ex.Message);
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var response = new ResponseDto();

            try
            {
                var result = await _dbSet.FindAsync(id);

                if (result != null)
                {
                    _dbSet.Remove(result);
                    response.Success = true;
                    return response;
                }

                response.Message = $"Record {id} does not exist and was not deleted.";
                response.Success = false;
            }
            catch(Exception ex) 
            {
                _logger.LogError("{nameOf} threw an exception of {ex} with a message of {message}", nameof(DeleteAsync), ex, ex.Message);
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("{nameOf} threw an exception of {ex} with a message of {message}", nameof(GetAllAsync), ex, ex.Message);
            }

            return Enumerable.Empty<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch(Exception ex) 
            {
                _logger.LogError("{nameOf} threw an exception of {ex} with a message of {message}", nameof(GetByIdAsync), ex, ex.Message);
            }

            return null;
        }

        public async Task<ResponseDto> SaveAsync(CancellationToken cancellationToken = default)
        {
            var response = new ResponseDto();

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                response.Success = true;
            } catch(Exception ex) 
            {
                _logger.LogError("{nameOf} threw an exception of {ex} with a message of {message}", nameof(SaveAsync), ex, ex.Message);
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseDto> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var response = new ResponseDto();

            try
            {
                await Task.FromResult(_dbSet.Update(entity).Entity);
                response.Success = true;
            }
            catch(Exception ex)
            {
                _logger.LogError("{nameOf} threw an exception of {ex} with a message of {message}", nameof(UpdateAsync), ex, ex.Message);
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
