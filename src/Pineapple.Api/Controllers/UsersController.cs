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
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            if (mediator is null)
            {
                throw new ArgumentNullException(nameof(mediator));
            }

            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUsers()
        {
            GetUsersCommand command = new();
            Task<UserDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            UserDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("administrators")]
        public async Task<IActionResult> GetAdministrators()
        {
            GetAdministratorsCommand command = new();
            Task<UserDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            UserDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("administrators")]
        public async Task<IActionResult> CreateAdministrator([FromBody]CreateAdministratorDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateAdministratorCommand command = new(dto.FullName, dto.Login, dto.Phone, dto.Email);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/users/{result}", null);
        }

        [HttpGet]
        [Route("developers")]
        public async Task<IActionResult> GetDevelopers()
        {
            GetDevelopersCommand command = new();
            Task<UserDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            UserDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("developers")]
        public async Task<IActionResult> CreateDeveloper([FromBody]CreateDeveloperDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateDeveloperCommand command = new(dto.FullName, dto.Login, dto.Phone, dto.Email);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/users/{result}", null);
        }

        [HttpGet]
        [Route("managers")]
        public async Task<IActionResult> GetManagers()
        {
            GetManagersCommand command = new();
            Task<UserDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            UserDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("managers")]
        public async Task<IActionResult> CreateManager([FromBody]CreateManagerDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateManagerCommand command = new(dto.FullName, dto.Login, dto.Phone, dto.Email);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/users/{result}", null);
        }

        [HttpGet]
        [Route("operators")]
        public async Task<IActionResult> GetOperators()
        {
            GetOperatorsCommand command = new();
            Task<UserDto[]> resultTask = await mediator.Send(command).ConfigureAwait(false);
            UserDto[] result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [Route("operators")]
        public async Task<IActionResult> CreateOperator([FromBody]CreateOperatorDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            CreateOperatorCommand command = new(dto.FullName, dto.Login, dto.Phone, dto.Email);
            Task<Guid> resultTask = await mediator.Send(command).ConfigureAwait(false);
            Guid result = await resultTask.ConfigureAwait(false);

            return Created($"/users/{result}", null);
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            DeleteUserCommand command = new(Guid.Parse(userId));
            await mediator.Send(command).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            GetUserCommand command = new(Guid.Parse(userId));
            Task<UserDto> resultTask = await mediator.Send(command).ConfigureAwait(false);
            UserDto result = await resultTask.ConfigureAwait(false);

            return Ok(result);
        }
    }
}
