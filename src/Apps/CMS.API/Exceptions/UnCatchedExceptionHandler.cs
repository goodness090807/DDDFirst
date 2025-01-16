using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Exceptions
{
    public class UnCatchedExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<UnCatchedExceptionHandler> _logger;

        public UnCatchedExceptionHandler(ILogger<UnCatchedExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message, exception.InnerException);

            var problemDetails = new ProblemDetails
            {
                Title = "服務發生錯誤",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} / {httpContext.Request.Path}",
                Extensions =
                {
                    ["traceId"] = Activity.Current?.Id ?? httpContext.TraceIdentifier
                }
            };

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
