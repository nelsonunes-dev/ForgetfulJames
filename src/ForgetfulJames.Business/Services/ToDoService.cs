using AutoMapper;
using ForgetfulJames.Business.Abstractions.Services;
using ForgetfulJames.Data.Abstractions.Repositories;
using ForgetfulJames.Domain.Entities;
using ForgetfulJames.Dto.Entities;
using ForgetfulJames.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgetfulJames.Business.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository toDoRepository, IMapper mapper) 
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> AddAsync(ToDoDto entity, CancellationToken cancellationToken = default)
        {
            var toDo = _mapper.Map<ToDo>(entity);
            return await _toDoRepository.AddAsync(toDo, cancellationToken);
        }

        public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _toDoRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<ToDoDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<ToDoDto>>(await _toDoRepository.GetAllAsync(cancellationToken));
        }

        public async Task<ToDoDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<ToDoDto>(await _toDoRepository.GetByIdAsync(id, cancellationToken));
        }

        public async Task<ResponseDto> UpdateAsync(ToDoDto entity, CancellationToken cancellationToken = default)
        {
            var toDo = _mapper.Map<ToDo>(entity);
            return await _toDoRepository.UpdateAsync(toDo, cancellationToken);
        }
    }
}
