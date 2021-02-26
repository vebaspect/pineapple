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

        [HttpDelete]
        [Route("component-types/{componentTypeId}")]
        public async Task<IActionResult> DeleteComponentType(Guid componentTypeId)
        {
            DeleteComponentTypeCommand command = new(componentTypeId);
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
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

        [HttpGet]
        [Route("operating-systems")]
        public async Task<IActionResult> GetOperatingSystems()
        {
            GetOperatingSystemsCommand command = new();
            Task<OperatingSystemDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            OperatingSystemDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("operating-systems")]
        public async Task<IActionResult> CreateOperatingSystem([FromBody]CreateOperatingSystemDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateOperatingSystemCommand command = new(dto.Name, dto.Symbol, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/operating-systems/{result}", null);
        }

        [HttpDelete]
        [Route("operating-systems/{operatingSystemId}")]
        public async Task<IActionResult> DeleteOperatingSystem(Guid operatingSystemId)
        {
            DeleteOperatingSystemCommand command = new(operatingSystemId);
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [Route("operating-systems/{operatingSystemId}")]
        public async Task<IActionResult> GetOperatingSystem(Guid operatingSystemId)
        {
            GetOperatingSystemCommand command = new(operatingSystemId);
            Task<OperatingSystemDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            OperatingSystemDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("software-applications")]
        public async Task<IActionResult> GetSoftwareApplications()
        {
            GetSoftwareApplicationsCommand command = new();
            Task<SoftwareApplicationDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            SoftwareApplicationDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("software-applications")]
        public async Task<IActionResult> CreateSoftwareApplication([FromBody]CreateSoftwareApplicationDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateSoftwareApplicationCommand command = new(dto.Name, dto.Symbol, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/software-applications/{result}", null);
        }

        [HttpDelete]
        [Route("software-applications/{softwareApplicationId}")]
        public async Task<IActionResult> DeleteSoftwareApplication(Guid softwareApplicationId)
        {
            DeleteSoftwareApplicationCommand command = new(softwareApplicationId);
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [Route("software-applications/{softwareApplicationId}")]
        public async Task<IActionResult> GetSoftwareApplication(Guid softwareApplicationId)
        {
            GetSoftwareApplicationCommand command = new(softwareApplicationId);
            Task<SoftwareApplicationDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            SoftwareApplicationDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
