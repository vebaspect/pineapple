using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pineapple.Core.Domain.Exceptions;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Validation;

namespace Pineapple.Api.Filters
{
    /// <summary>
    /// Globalna obsługa wyjątków.
    /// </summary>
    public class GlobalExceptionActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Wyjątki na poziomie "Pineapple.Core":

            if (context.Exception is ComponentNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is ComponentTypeAlreadyExistsException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is ComponentTypeNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is ComponentVersionAlreadyExistsException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is ComponentVersionNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is EnvironmentAlreadyExistsException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is EnvironmentNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is ImplementationNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is OperatingSystemAlreadyExistsException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is OperatingSystemNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is ProductNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is ServerAlreadyExistsException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is ServerNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is ServerComponentNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is SoftwareApplicationAlreadyExistsException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is SoftwareApplicationNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is UserAlreadyExistsException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is UserNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }

            // Wyjątki na poziomie "Pineapple.Core.Domain":

            if (context.Exception is ValueRequiredValidationException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Content = JsonSerializer.Serialize(
                        new
                        {
                            Property = context.Exception.Message,
                            ErrorType = AvailableValidationErrorTypes.ValueRequired
                        },
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        }
                    ),
                    ContentType = "application/json",
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
