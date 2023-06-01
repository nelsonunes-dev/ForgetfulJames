using ForgetfulJames.Business.Abstractions.Business;
using ForgetfulJames.Data.Abstractions.Common;
using ForgetfulJames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgetfulJames.Data.Abstractions.Repositories
{
    public interface IToDoRepository : IToDo, IRepository<ToDo> { }
}
