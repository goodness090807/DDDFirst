using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace CMS.API.Exceptions
{
    [Obsolete("雖然IExceptionHandler可以比較簡單的做例外處理，但為引發Log觸發兩次的問題，所以不使用")]
    public class UnCatchedExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public UnCatchedExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

            _logger.Error(exception, "發生未處理的錯誤: {Method} {Path} | TraceId: {TraceId}",
                httpContext.Request.Method, httpContext.Request.Path, traceId);

            var problemDetails = new ProblemDetails
            {
                Title = "服務發生錯誤",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                Extensions =
                {
                    ["traceId"] = traceId
                }
            };

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
