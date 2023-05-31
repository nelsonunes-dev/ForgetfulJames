using ForgetfulJames.Dto.Response;

namespace ForgetfulJames.Business.Abstractions.Common
{
    public interface IServiceBase<T> where T : class 
    {
        Task<ResponseDto> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ResponseDto> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}
