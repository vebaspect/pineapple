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

        [HttpGet]
        [Route("component-types/count")]
        public async Task<IActionResult> GetComponentTypesCount()
        {
            GetComponentTypesCountCommand command = new();
            Task<int> resultTask = await mediator.Send(command).ConfigureAwait(false);
            int result = await resultTask.ConfigureAwait(false);

            return Ok(new { value = result });
        }

        [HttpPost]
        [Route("component-types")]
        public async Task<IActionResult> CreateComponentType([FromBody]CreateComponentTypeDto dto)
        {
            if (dto is null)
            {
                return BadRequest("ComponentType data has not been provided");
            }

            CreateComponentTypeCommand command = new(dto.Name, dto.Symbol, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/component-types/{result}", null);
        }

        [HttpDelete]
        [Route("component-types/{componentTypeId}")]
        public async Task<IActionResult> DeleteComponentType(string componentTypeId)
        {
            if (componentTypeId is null || !Guid.TryParse(componentTypeId, out _))
            {
                return BadRequest("ComponentType identifier has not been provided");
            }

            DeleteComponentTypeCommand command = new(Guid.Parse(componentTypeId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [Route("component-types/{componentTypeId}")]
        public async Task<IActionResult> GetComponentType(string componentTypeId)
        {
            if (componentTypeId is null || !Guid.TryParse(componentTypeId, out _))
            {
                return BadRequest("ComponentType identifier has not been provided");
            }

            GetComponentTypeCommand command = new(Guid.Parse(componentTypeId));
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

        [HttpGet]
        [Route("operating-systems/count")]
        public async Task<IActionResult> GetOperatingSystemsCount()
        {
            GetOperatingSystemsCountCommand command = new();
            Task<int> resultTask = await mediator.Send(command).ConfigureAwait(false);
            int result = await resultTask.ConfigureAwait(false);

            return Ok(new { value = result });
        }

        [HttpPost]
        [Route("operating-systems")]
        public async Task<IActionResult> CreateOperatingSystem([FromBody]CreateOperatingSystemDto dto)
        {
            if (dto is null)
            {
                return BadRequest("OperatingSystem data has not been provided");
            }

            CreateOperatingSystemCommand command = new(dto.Name, dto.Symbol, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/operating-systems/{result}", null);
        }

        [HttpDelete]
        [Route("operating-systems/{operatingSystemId}")]
        public async Task<IActionResult> DeleteOperatingSystem(string operatingSystemId)
        {
            if (operatingSystemId is null || !Guid.TryParse(operatingSystemId, out _))
            {
                return BadRequest("OperatingSystem identifier has not been provided");
            }

            DeleteOperatingSystemCommand command = new(Guid.Parse(operatingSystemId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [Route("operating-systems/{operatingSystemId}")]
        public async Task<IActionResult> GetOperatingSystem(string operatingSystemId)
        {
            if (operatingSystemId is null || !Guid.TryParse(operatingSystemId, out _))
            {
                return BadRequest("OperatingSystem identifier has not been provided");
            }

            GetOperatingSystemCommand command = new(Guid.Parse(operatingSystemId));
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
                return BadRequest("SoftwareApplication data has not been provided");
            }

            CreateSoftwareApplicationCommand command = new(dto.Name, dto.Symbol, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/software-applications/{result}", null);
        }

        [HttpDelete]
        [Route("software-applications/{softwareApplicationId}")]
        public async Task<IActionResult> DeleteSoftwareApplication(string softwareApplicationId)
        {
            if (softwareApplicationId is null || !Guid.TryParse(softwareApplicationId, out _))
            {
                return BadRequest("SoftwareApplication identifier has not been provided");
            }

            DeleteSoftwareApplicationCommand command = new(Guid.Parse(softwareApplicationId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [Route("software-applications/{softwareApplicationId}")]
        public async Task<IActionResult> GetSoftwareApplication(string softwareApplicationId)
        {
            if (softwareApplicationId is null || !Guid.TryParse(softwareApplicationId, out _))
            {
                return BadRequest("SoftwareApplication identifier has not been provided");
            }

            GetSoftwareApplicationCommand command = new(Guid.Parse(softwareApplicationId));
            Task<SoftwareApplicationDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            SoftwareApplicationDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
