using ForgetfulJames.Dto.Response;

namespace ForgetfulJames.Data.Abstractions.Common
{
    public interface IRepository<T> where T : class
    {
        Task<ResponseDto> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ResponseDto> SaveAsync(CancellationToken cancellationToken = default);
        Task<ResponseDto> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}
