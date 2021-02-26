using System;
using System.Threading.Tasks;
using Pineapple.Api.Controllers.Dto;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Pineapple.Api.Controllers
{
    [ApiController]
    [Route("implementations")]
    public class ImplementationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ImplementationsController(IMediator mediator)
        {
            if (mediator is null)
            {
                throw new ArgumentNullException(nameof(mediator));
            }

            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetImplementations()
        {
            GetImplementationsCommand command = new();
            Task<ImplementationDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ImplementationDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateImplementation([FromBody]CreateImplementationDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateImplementationCommand command = new(dto.Name, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/implementations/{result}", null);
        }

        [HttpGet]
        [Route("{implementationId}")]
        public async Task<IActionResult> GetImplementation(string implementationId)
        {
            GetImplementationCommand command = new(Guid.Parse(implementationId));
            Task<ImplementationDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ImplementationDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{implementationId}/coordinators")]
        public async Task<IActionResult> GetCoordinators(string implementationId)
        {
            GetCoordinatorsCommand command = new(Guid.Parse(implementationId));
            Task<CoordinatorDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            CoordinatorDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{implementationId}/coordinators")]
        public async Task<IActionResult> CreateCoordinator(string implementationId, [FromBody]CreateCoordinatorDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateCoordinatorCommand command = new(Guid.Parse(implementationId), dto.FullName, dto.Phone, dto.Email);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/implementations/{implementationId}/coordinators/{result}", null);
        }

        [HttpGet]
        [Route("{implementationId}/coordinators/{coordinatorId}")]
        public async Task<IActionResult> GetCoordinator(string implementationId, string coordinatorId)
        {
            GetCoordinatorCommand command = new(Guid.Parse(implementationId), Guid.Parse(coordinatorId));
            Task<CoordinatorDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            CoordinatorDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{implementationId}/environments")]
        public async Task<IActionResult> GetEnvironments(string implementationId)
        {
            GetEnvironmentsCommand command = new(Guid.Parse(implementationId));
            Task<EnvironmentDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            EnvironmentDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{implementationId}/environments")]
        public async Task<IActionResult> CreateEnvironment(string implementationId, [FromBody]CreateEnvironmentDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateEnvironmentCommand command = new(Guid.Parse(implementationId), dto.Name, dto.Symbol, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/implementations/{implementationId}/environments/{result}", null);
        }

        [HttpGet]
        [Route("{implementationId}/environments/{environmentId}")]
        public async Task<IActionResult> GetEnvironment(string implementationId, string environmentId)
        {
            GetEnvironmentCommand command = new(Guid.Parse(implementationId), Guid.Parse(environmentId));
            Task<EnvironmentDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            EnvironmentDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{implementationId}/environments/{environmentId}/servers")]
        public async Task<IActionResult> GetServers(string implementationId, string environmentId)
        {
            GetServersCommand command = new(Guid.Parse(implementationId), Guid.Parse(environmentId));
            Task<ServerDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ServerDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{implementationId}/environments/{environmentId}/servers")]
        public async Task<IActionResult> CreateServer(string implementationId, string environmentId, [FromBody]CreateServerDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateServerCommand command = new(Guid.Parse(environmentId), dto.Name, dto.Symbol, dto.Description, dto.OperatingSystemId, dto.IPAddress);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/implementations/{implementationId}/environments/{environmentId}/servers/{result}", null);
        }

        [HttpGet]
        [Route("{implementationId}/environments/{environmentId}/servers/{serverId}")]
        public async Task<IActionResult> GetServer(string implementationId, string environmentId, string serverId)
        {
            GetServerCommand command = new(Guid.Parse(implementationId), Guid.Parse(environmentId), Guid.Parse(serverId));
            Task<ServerDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ServerDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
