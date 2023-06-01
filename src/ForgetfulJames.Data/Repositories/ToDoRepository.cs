using ForgetfulJames.Data.Abstractions.Repositories;
using ForgetfulJames.Data.Common;
using ForgetfulJames.Domain.Entities;
using ForgetfulJames.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgetfulJames.Data.Repositories
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ApplicationDbContext dbContext, ILogger<ToDo> logger) : base(dbContext, logger) { }
    }
}
