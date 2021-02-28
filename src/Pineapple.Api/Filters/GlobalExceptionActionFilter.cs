using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pineapple.Core.Exceptions;

namespace Pineapple.Api.Filters
{
    /// <summary>
    /// Globalna obsługa wyjątków.
    /// </summary>
    public class GlobalExceptionActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
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
            if (context.Exception is CoordinatorNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
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
            if (context.Exception is VersionNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Content = context.Exception.Message,
                    ContentType = "text/plain",
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
