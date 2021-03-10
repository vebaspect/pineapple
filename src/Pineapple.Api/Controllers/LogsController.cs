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
        [Route("implementations")]
        public async Task<IActionResult> GetImplementationsLogs()
        {
            GetImplementationsLogsCommand command = new();
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
    }
}
