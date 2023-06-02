using ForgetfulJames.Api.Authentication;
using ForgetfulJames.Business.Abstractions.Services;
using ForgetfulJames.Dto.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ForgetfulJames.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService) 
        {
            _toDoService = toDoService;
        }

        [ApiVersion("1.0")]
        [Authorize]
        [HttpPost("AddAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] ToDoDto entity, CancellationToken cancellationToken = default)
        {
            var response = await _toDoService.AddAsync(entity, cancellationToken);

            if (response == null)
                return BadRequest();

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [ApiVersion("1.0")]
        [Authorize]
        [HttpDelete("DeleteAsync/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var response = await _toDoService.DeleteAsync(Guid.Parse(id), cancellationToken);

            if (response == null)
                return BadRequest();

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [EnableQuery(PageSize = 10)]
        [HttpGet("GetAllAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = await _toDoService.GetAllAsync(cancellationToken);

            if (response == null)
                return BadRequest(response);

            return Ok(response);
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpGet("GetByUserIdAsync/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            var response = await _toDoService.GetByUserIdAsync(userId, cancellationToken);

            if (response == null)
                return BadRequest(response);

            return Ok(response);
        }

        [ApiVersion("1.0")]
        [Authorize]
        [HttpPost("UpdateAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] ToDoDto entity, CancellationToken cancellationToken = default)
        {
            var response = await _toDoService.UpdateAsync(entity, cancellationToken);

            if (response == null)
                return BadRequest();

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }
    }
}
