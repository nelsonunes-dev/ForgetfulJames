using ForgetfulJames.Business.Abstractions.Business;
using ForgetfulJames.Data.Abstractions.Common;
using ForgetfulJames.Domain.Entities;

namespace ForgetfulJames.Data.Abstractions.Repositories
{
    public interface IToDoRepository : IToDo, IRepository<ToDo> 
    {
        Task<IEnumerable<ToDo>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    }
}
