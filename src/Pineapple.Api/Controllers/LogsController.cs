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
    [Route("logs")]
    public class LogsController : ControllerBase
    {
        private readonly IMediator mediator;

        public LogsController(IMediator mediator)
        {
            if (mediator is null)
            {
                throw new ArgumentNullException(nameof(mediator));
            }

            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetLogs([FromQuery]int? count)
        {
            GetLogsCommand command = new(count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("components")]
        public async Task<IActionResult> GetComponentsLogs([FromQuery]int? count)
        {
            GetComponentsLogsCommand command = new(count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("components/{componentId}")]
        public async Task<IActionResult> GetComponentLogs(string componentId, [FromQuery]int? count)
        {
            if (componentId is null || !Guid.TryParse(componentId, out _))
            {
                return BadRequest("Component identifier has not been provided");
            }

            GetComponentLogsCommand command = new(Guid.Parse(componentId), count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("configuration")]
        public async Task<IActionResult> GetConfigurationLogs([FromQuery]int? count)
        {
            GetConfigurationLogsCommand command = new(count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("environments")]
        public async Task<IActionResult> GetEnvironmentsLogs([FromQuery]int? count)
        {
            GetEnvironmentsLogsCommand command = new(count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("environments/{environmentId}")]
        public async Task<IActionResult> GetEnvironmentLogs(string environmentId, [FromQuery]int? count)
        {
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }

            GetEnvironmentLogsCommand command = new(Guid.Parse(environmentId), count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("implementations")]
        public async Task<IActionResult> GetImplementationsLogs([FromQuery]int? count)
        {
            GetImplementationsLogsCommand command = new(count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("implementations/{implementationId}")]
        public async Task<IActionResult> GetImplementationLogs(string implementationId, [FromQuery]int? count)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }

            GetImplementationLogsCommand command = new(Guid.Parse(implementationId), count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProductsLogs([FromQuery]int? count)
        {
            GetProductsLogsCommand command = new(count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("products/{productId}")]
        public async Task<IActionResult> GetProductLogs(string productId, [FromQuery]int? count)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }

            GetProductLogsCommand command = new(Guid.Parse(productId), count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("servers")]
        public async Task<IActionResult> GetServersLogs([FromQuery]int? count)
        {
            GetServersLogsCommand command = new(count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("servers/{serverId}")]
        public async Task<IActionResult> GetServerLogs(string serverId, [FromQuery]int? count)
        {
            if (serverId is null || !Guid.TryParse(serverId, out _))
            {
                return BadRequest("Server identifier has not been provided");
            }

            GetServerLogsCommand command = new(Guid.Parse(serverId), count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsersLogs([FromQuery]int? count)
        {
            GetUsersLogsCommand command = new(count);
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
