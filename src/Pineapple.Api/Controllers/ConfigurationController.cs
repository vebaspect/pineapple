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
    [Route("configuration")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IMediator mediator;

        public ConfigurationController(IMediator mediator)
        {
            if (mediator is null)
            {
                throw new ArgumentNullException(nameof(mediator));
            }

            this.mediator = mediator;
        }

        [HttpGet]
        [Route("component-types")]
        public async Task<IActionResult> GetComponentTypes()
        {
            GetComponentTypesCommand command = new();
            Task<ComponentTypeDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ComponentTypeDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("component-types")]
        public async Task<IActionResult> CreateComponentType([FromBody]CreateComponentTypeDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateComponentTypeCommand command = new(dto.Name, dto.Symbol, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/component-types/{result}", null);
        }

        [HttpGet]
        [Route("component-types/{componentTypeId}")]
        public async Task<IActionResult> GetComponentType(Guid componentTypeId)
        {
            GetComponentTypeCommand command = new(componentTypeId);
            Task<ComponentTypeDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ComponentTypeDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
