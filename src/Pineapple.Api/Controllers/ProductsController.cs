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
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            GetProductCommand command = new(productId);
            Task<ProductDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ProductDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{productId}/components")]
        public async Task<IActionResult> GetComponents(Guid productId)
        {
            GetComponentsCommand command = new(productId);
            Task<ComponentDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ComponentDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("{productId}/components")]
        public async Task<IActionResult> CreateComponent(Guid productId, [FromBody]CreateComponentDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateComponentCommand command = new(productId, dto.Name, dto.Description);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/products/{productId}/components/{result}", null);
        }

        [HttpGet]
        [Route("{productId}/components/{componentId}")]
        public async Task<IActionResult> GetComponent(Guid productId, Guid componentId)
        {
            GetComponentCommand command = new(productId, componentId);
            Task<ComponentDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            ComponentDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
