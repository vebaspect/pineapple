using System;
using System.Threading.Tasks;
using Pineapple.Api.Controllers.Dto;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Dto.ProductsTree;
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
        public async Task<IActionResult> GetProducts([FromQuery]int? count)
        {
            GetProductsCommand command = new(count);
            Task<ProductDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ProductDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("tree")]
        public async Task<IActionResult> GetProductsTree()
        {
            GetProductsTreeCommand command = new();
            Task<ProductsTreeDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ProductsTreeDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Product data has not been provided");
            }

            CreateProductCommand command = new(dto.Name, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/products/{result}", null);
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }

            DeleteProductCommand command = new(Guid.Parse(productId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
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
                return BadRequest("Component data has not been provided");
            }

            CreateComponentCommand command = new(Guid.Parse(productId), dto.Name, dto.SourceCodeRepositoryUrl, dto.Description, dto.ComponentTypeId);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/products/{productId}/components/{result}", null);
        }

        [HttpDelete]
        [Route("{productId}/components/{componentId}")]
        public async Task<IActionResult> DeleteComponent(string productId, string componentId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }
            if (componentId is null || !Guid.TryParse(componentId, out _))
            {
                return BadRequest("Component identifier has not been provided");
            }

            DeleteComponentCommand command = new(Guid.Parse(productId), Guid.Parse(componentId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
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
        [Route("{productId}/components/{componentId}/component-versions")]
        public async Task<IActionResult> GetComponentVersions(string productId, string componentId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }
            if (componentId is null || !Guid.TryParse(componentId, out _))
            {
                return BadRequest("Component identifier has not been provided");
            }

            GetComponentVersionsCommand command = new(Guid.Parse(productId), Guid.Parse(componentId));
            Task<ComponentVersionDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ComponentVersionDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{productId}/components/{componentId}/component-versions")]
        public async Task<IActionResult> CreateComponentVersion(string productId, string componentId, [FromBody]CreateComponentVersionDto dto)
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
                return BadRequest("ComponentVersion data has not been provided");
            }
            if (dto.ReleaseDate is null || !DateTime.TryParse(dto.ReleaseDate, out _))
            {
                return BadRequest("ReleaseDate has not been provided");
            }

            CreateComponentVersionCommand command = new(Guid.Parse(componentId), DateTime.Parse(dto.ReleaseDate), dto.Major, dto.Minor, dto.Patch, dto.Suffix, dto.IssueTrackingSystemTicketUrl, dto.Description, dto.IsImportant);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/products/{productId}/components/{componentId}/component-versions/{result}", null);
        }

        [HttpDelete]
        [Route("{productId}/components/{componentId}/component-versions/{componentVersionId}")]
        public async Task<IActionResult> DeleteComponentVersion(string productId, string componentId, string componentVersionId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }
            if (componentId is null || !Guid.TryParse(componentId, out _))
            {
                return BadRequest("Component identifier has not been provided");
            }
            if (componentVersionId is null || !Guid.TryParse(componentVersionId, out _))
            {
                return BadRequest("ComponentVersion identifier has not been provided");
            }

            DeleteComponentVersionCommand command = new(Guid.Parse(productId), Guid.Parse(componentId), Guid.Parse(componentVersionId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [Route("{productId}/components/{componentId}/component-versions/{componentVersionId}")]
        public async Task<IActionResult> GetComponentVersion(string productId, string componentId, string componentVersionId)
        {
            if (productId is null || !Guid.TryParse(productId, out _))
            {
                return BadRequest("Product identifier has not been provided");
            }
            if (componentId is null || !Guid.TryParse(componentId, out _))
            {
                return BadRequest("Component identifier has not been provided");
            }
            if (componentVersionId is null || !Guid.TryParse(componentVersionId, out _))
            {
                return BadRequest("ComponentVersion identifier has not been provided");
            }

            GetComponentVersionCommand command = new(Guid.Parse(productId), Guid.Parse(componentId), Guid.Parse(componentVersionId));
            Task<ComponentVersionDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ComponentVersionDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
