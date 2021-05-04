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
        public async Task<IActionResult> GetImplementations([FromQuery]int? count)
        {
            GetImplementationsCommand command = new(count);
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
                return BadRequest("Implementation data has not been provided");
            }

            CreateImplementationCommand command = new(dto.Name, dto.Description, dto.ManagerId);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/implementations/{result}", null);
        }

        [HttpDelete]
        [Route("{implementationId}")]
        public async Task<IActionResult> DeleteImplementation(string implementationId)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }

            DeleteImplementationCommand command = new(Guid.Parse(implementationId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [Route("{implementationId}")]
        public async Task<IActionResult> GetImplementation(string implementationId)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }

            GetImplementationCommand command = new(Guid.Parse(implementationId));
            Task<ImplementationDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ImplementationDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{implementationId}/environments")]
        public async Task<IActionResult> GetEnvironments(string implementationId)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }

            GetEnvironmentsCommand command = new(Guid.Parse(implementationId));
            Task<EnvironmentDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            EnvironmentDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{implementationId}/environments")]
        public async Task<IActionResult> CreateEnvironment(string implementationId, [FromBody]CreateEnvironmentDto dto)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }

            if (dto is null)
            {
                return BadRequest("Environment data has not been provided");
            }

            CreateEnvironmentCommand command = new(Guid.Parse(implementationId), dto.Name, dto.Symbol, dto.Description, dto.OperatorId);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/implementations/{implementationId}/environments/{result}", null);
        }

        [HttpDelete]
        [Route("{implementationId}/environments/{environmentId}")]
        public async Task<IActionResult> DeleteEnvironment(string implementationId, string environmentId)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }

            DeleteEnvironmentCommand command = new(Guid.Parse(implementationId), Guid.Parse(environmentId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [Route("{implementationId}/environments/{environmentId}")]
        public async Task<IActionResult> GetEnvironment(string implementationId, string environmentId)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }

            GetEnvironmentCommand command = new(Guid.Parse(implementationId), Guid.Parse(environmentId));
            Task<EnvironmentDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            EnvironmentDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{implementationId}/environments/{environmentId}/servers")]
        public async Task<IActionResult> GetServers(string implementationId, string environmentId)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }

            GetServersCommand command = new(Guid.Parse(implementationId), Guid.Parse(environmentId));
            Task<ServerDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ServerDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{implementationId}/environments/{environmentId}/servers")]
        public async Task<IActionResult> CreateServer(string implementationId, string environmentId, [FromBody]CreateServerDto dto)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }

            if (dto is null)
            {
                return BadRequest("Server data has not been provided");
            }

            CreateServerCommand command = new(Guid.Parse(environmentId), dto.Name, dto.Symbol, dto.IpAddress, dto.Description, dto.OperatingSystemId);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/implementations/{implementationId}/environments/{environmentId}/servers/{result}", null);
        }

        [HttpDelete]
        [Route("{implementationId}/environments/{environmentId}/servers/{serverId}")]
        public async Task<IActionResult> DeleteServer(string implementationId, string environmentId, string serverId)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }
            if (serverId is null || !Guid.TryParse(serverId, out _))
            {
                return BadRequest("Server identifier has not been provided");
            }

            DeleteServerCommand command = new(Guid.Parse(implementationId), Guid.Parse(environmentId), Guid.Parse(serverId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [Route("{implementationId}/environments/{environmentId}/servers/{serverId}")]
        public async Task<IActionResult> GetServer(string implementationId, string environmentId, string serverId)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }
            if (serverId is null || !Guid.TryParse(serverId, out _))
            {
                return BadRequest("Server identifier has not been provided");
            }

            GetServerCommand command = new(Guid.Parse(implementationId), Guid.Parse(environmentId), Guid.Parse(serverId));
            Task<ServerDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ServerDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{implementationId}/environments/{environmentId}/servers/{serverId}/components")]
        public async Task<IActionResult> InstallComponent(string implementationId, string environmentId, string serverId, [FromBody]InstallComponentDto dto)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }
            if (serverId is null || !Guid.TryParse(serverId, out _))
            {
                return BadRequest("Server identifier has not been provided");
            }

            if (dto is null)
            {
                return BadRequest("ComponentVersion installation data has not been provided");
            }
            if (dto.ComponentVersionId is null || !Guid.TryParse(dto.ComponentVersionId, out _))
            {
                return BadRequest("ComponentVersion has not been provided");
            }

            InstallComponentCommand command = new(Guid.Parse(serverId), Guid.Parse(dto.ComponentVersionId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete]
        [Route("{implementationId}/environments/{environmentId}/servers/{serverId}/components")]
        public async Task<IActionResult> UninstallComponent(string implementationId, string environmentId, string serverId, [FromBody]UninstallComponentDto dto)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }
            if (serverId is null || !Guid.TryParse(serverId, out _))
            {
                return BadRequest("Server identifier has not been provided");
            }

            if (dto is null)
            {
                return BadRequest("ComponentVersion uninstallation data has not been provided");
            }
            if (dto.ComponentVersionId is null || !Guid.TryParse(dto.ComponentVersionId, out _))
            {
                return BadRequest("ComponentVersion has not been provided");
            }

            UninstallComponentCommand command = new(Guid.Parse(serverId), Guid.Parse(dto.ComponentVersionId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpPost]
        [Route("{implementationId}/environments/{environmentId}/servers/{serverId}/software-applications")]
        public async Task<IActionResult> InstallSoftwareApplication(string implementationId, string environmentId, string serverId, [FromBody]InstallSoftwareApplicationDto dto)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }
            if (serverId is null || !Guid.TryParse(serverId, out _))
            {
                return BadRequest("Server identifier has not been provided");
            }

            if (dto is null)
            {
                return BadRequest("SoftwareApplication installation data has not been provided");
            }
            if (dto.SoftwareApplicationId is null || !Guid.TryParse(dto.SoftwareApplicationId, out _))
            {
                return BadRequest("SoftwareApplication has not been provided");
            }

            InstallSoftwareApplicationCommand command = new(Guid.Parse(serverId), Guid.Parse(dto.SoftwareApplicationId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete]
        [Route("{implementationId}/environments/{environmentId}/servers/{serverId}/software-applications")]
        public async Task<IActionResult> UninstallSoftwareApplication(string implementationId, string environmentId, string serverId, [FromBody]UninstallSoftwareApplicationDto dto)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }
            if (serverId is null || !Guid.TryParse(serverId, out _))
            {
                return BadRequest("Server identifier has not been provided");
            }

            if (dto is null)
            {
                return BadRequest("SoftwareApplication uninstallation data has not been provided");
            }
            if (dto.SoftwareApplicationId is null || !Guid.TryParse(dto.SoftwareApplicationId, out _))
            {
                return BadRequest("SoftwareApplication has not been provided");
            }

            UninstallSoftwareApplicationCommand command = new(Guid.Parse(serverId), Guid.Parse(dto.SoftwareApplicationId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }
    }
}
