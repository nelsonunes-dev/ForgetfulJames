using ForgetfulJames.Api.Authentication;
using ForgetfulJames.Business.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForgetfulJames.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InitialiseInfrastructureController : ControllerBase
    {
        private readonly IInitialiseInfrastructureService _infrastructureService;

        public InitialiseInfrastructureController(IInitialiseInfrastructureService infrastructureService)
        {
            _infrastructureService = infrastructureService;
        }

        /// <summary>
        /// Initialises the database and runs migrations.
        /// </summary>
        /// <param name="cancellationToken">Propagates notification that operations should be cancelled.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpPost("InitialiseDatabaseAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InitialiseDatabaseAsync(CancellationToken cancellationToken = default)
        {
            await _infrastructureService.InitialiseDatabaseAsync(cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Seeds the database based on settings found in the appsettings.json file.
        /// </summary>
        /// <param name="cancellationToken">Propagates notification that operations should be cancelled.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpPost("SeedDatabaseAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SeedDatabaseAsync(CancellationToken cancellationToken = default)
        {
            await _infrastructureService.SeedDatabaseAsync(cancellationToken);
            return Ok();
        }
    }
}
