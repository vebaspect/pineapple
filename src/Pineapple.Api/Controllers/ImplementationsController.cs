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
        public async Task<IActionResult> GetImplementation(Guid implementationId)
        {
            GetImplementationCommand command = new(implementationId);
            Task<ImplementationDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ImplementationDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{implementationId}/environments")]
        public async Task<IActionResult> GetEnvironments(Guid implementationId)
        {
            GetEnvironmentsCommand command = new(implementationId);
            Task<EnvironmentDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            EnvironmentDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{implementationId}/environments")]
        public async Task<IActionResult> CreateEnvironment(Guid implementationId, [FromBody]CreateEnvironmentDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateEnvironmentCommand command = new(implementationId, dto.Name, dto.Symbol, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/implementations/{implementationId}/environments/{result}", null);
        }

        [HttpGet]
        [Route("{implementationId}/environments/{environmentId}")]
        public async Task<IActionResult> GetEnvironment(Guid implementationId, Guid environmentId)
        {
            GetEnvironmentCommand command = new(implementationId, environmentId);
            Task<EnvironmentDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            EnvironmentDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{implementationId}/coordinators")]
        public async Task<IActionResult> GetCoordinators(Guid implementationId)
        {
            GetCoordinatorsCommand command = new(implementationId);
            Task<CoordinatorDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            CoordinatorDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{implementationId}/coordinators")]
        public async Task<IActionResult> CreateCoordinator(Guid implementationId, [FromBody]CreateCoordinatorDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateCoordinatorCommand command = new(implementationId, dto.FullName, dto.Phone, dto.Email);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/implementations/{implementationId}/coordinators/{result}", null);
        }

        [HttpGet]
        [Route("{implementationId}/coordinators/{coordinatorId}")]
        public async Task<IActionResult> GetCoordinator(Guid implementationId, Guid coordinatorId)
        {
            GetCoordinatorCommand command = new(implementationId, coordinatorId);
            Task<CoordinatorDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            CoordinatorDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
