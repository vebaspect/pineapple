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
        public async Task<IActionResult> GetLogs()
        {
            GetLogsCommand command = new();
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("components")]
        public async Task<IActionResult> GetComponentsLogs()
        {
            GetComponentsLogsCommand command = new();
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("components/{componentId}")]
        public async Task<IActionResult> GetComponentLogs(string componentId)
        {
            if (componentId is null || !Guid.TryParse(componentId, out _))
            {
                return BadRequest("Component identifier has not been provided");
            }

            GetComponentLogsCommand command = new(Guid.Parse(componentId));
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("configuration")]
        public async Task<IActionResult> GetConfigurationLogs()
        {
            GetConfigurationLogsCommand command = new();
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("environments")]
        public async Task<IActionResult> GetEnvironmentsLogs()
        {
            GetEnvironmentsLogsCommand command = new();
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("environments/{environmentId}")]
        public async Task<IActionResult> GetEnvironmentLogs(string environmentId)
        {
            if (environmentId is null || !Guid.TryParse(environmentId, out _))
            {
                return BadRequest("Environment identifier has not been provided");
            }

            GetEnvironmentLogsCommand command = new(Guid.Parse(environmentId));
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("implementations")]
        public async Task<IActionResult> GetImplementationsLogs()
        {
            GetImplementationsLogsCommand command = new();
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("implementations/{implementationId}")]
        public async Task<IActionResult> GetImplementationLogs(string implementationId)
        {
            if (implementationId is null || !Guid.TryParse(implementationId, out _))
            {
                return BadRequest("Implementation identifier has not been provided");
            }

            GetImplementationLogsCommand command = new(Guid.Parse(implementationId));
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProductsLogs()
        {
            GetProductsLogsCommand command = new();
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("products/{productId}")]
        public async Task<IActionResult> GetProductLogs(string productId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }

            GetProductLogsCommand command = new(Guid.Parse(productId));
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsersLogs()
        {
            GetUsersLogsCommand command = new();
            Task<LogDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            LogDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
