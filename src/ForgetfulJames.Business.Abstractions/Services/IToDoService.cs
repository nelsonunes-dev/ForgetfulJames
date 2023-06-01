using ForgetfulJames.Business.Abstractions.Business;
using ForgetfulJames.Business.Abstractions.Common;
using ForgetfulJames.Dto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgetfulJames.Business.Abstractions.Services
{
    public interface IToDoService : IServiceBase<ToDoDto>, IToDo { }
}
