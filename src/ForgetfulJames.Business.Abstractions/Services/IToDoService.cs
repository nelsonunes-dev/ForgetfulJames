using ForgetfulJames.Business.Abstractions.Business;
using ForgetfulJames.Business.Abstractions.Common;
using ForgetfulJames.Dto.Entities;

namespace ForgetfulJames.Business.Abstractions.Services
{
    public interface IToDoService : IServiceBase<ToDoDto>, IToDo { }
}
