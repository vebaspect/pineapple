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
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            if (mediator is null)
            {
                throw new ArgumentNullException(nameof(mediator));
            }

            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProducts()
        {
            GetProductsCommand command = new();
            Task<ProductDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ProductDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateProductCommand command = new(dto.Name, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/products/{result}", null);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProduct(string productId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }

            GetProductCommand command = new(Guid.Parse(productId));
            Task<ProductDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ProductDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{productId}/components")]
        public async Task<IActionResult> GetComponents(string productId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }

            GetComponentsCommand command = new(Guid.Parse(productId));
            Task<ComponentDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ComponentDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{productId}/components")]
        public async Task<IActionResult> CreateComponent(string productId, [FromBody]CreateComponentDto dto)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }

            if (dto is null)
            {
                return BadRequest();
            }

            CreateComponentCommand command = new(Guid.Parse(productId), dto.Name, dto.Description, dto.ComponentTypeId);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/products/{productId}/components/{result}", null);
        }

        [HttpGet]
        [Route("{productId}/components/{componentId}")]
        public async Task<IActionResult> GetComponent(string productId, string componentId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }
            if (componentId is null || !Guid.TryParse(componentId, out _))
            {
                return BadRequest("Component identifier has not been provided");
            }

            GetComponentCommand command = new(Guid.Parse(productId), Guid.Parse(componentId));
            Task<ComponentDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ComponentDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{productId}/components/{componentId}/versions")]
        public async Task<IActionResult> GetVersions(string productId, string componentId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }
            if (componentId is null || !Guid.TryParse(componentId, out _))
            {
                return BadRequest("Component identifier has not been provided");
            }

            GetVersionsCommand command = new(Guid.Parse(productId), Guid.Parse(componentId));
            Task<VersionDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            VersionDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{productId}/components/{componentId}/versions")]
        public async Task<IActionResult> CreateVersion(string productId, string componentId, [FromBody]CreateVersionDto dto)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }
            if (componentId is null || !Guid.TryParse(componentId, out _))
            {
                return BadRequest("Component identifier has not been provided");
            }

            if (dto is null)
            {
                return BadRequest();
            }

            CreateVersionCommand command = new(Guid.Parse(componentId), dto.Major, dto.Minor, dto.Patch, dto.PreRelease, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/products/{productId}/components/{componentId}/versions/{result}", null);
        }

        [HttpGet]
        [Route("{productId}/components/{componentId}/versions/{versionId}")]
        public async Task<IActionResult> GetVersion(string productId, string componentId, string versionId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }
            if (componentId is null || !Guid.TryParse(componentId, out _))
            {
                return BadRequest("Component identifier has not been provided");
            }
            if (versionId is null || !Guid.TryParse(versionId, out _))
            {
                return BadRequest("Version identifier has not been provided");
            }

            GetVersionCommand command = new(Guid.Parse(productId), Guid.Parse(componentId), Guid.Parse(versionId));
            Task<VersionDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            VersionDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
