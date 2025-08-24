using ECommercePlatform.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace ECommercePlatform.Filters
{
    public class LoggingActionFilter : IAsyncActionFilter
    {
        private readonly ILoggingService _loggingService;

        public LoggingActionFilter(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Log request details before the action executes
            var request = context.HttpContext.Request;
            var requestDetails = $"Request: {request.Method} {request.Path}";
            _loggingService.Log(requestDetails);

            // Execute the action
            var resultContext = await next();

            // Log response details after the action executes
            var response = resultContext.HttpContext.Response;
            var responseDetails = $"Response Status Code: {response.StatusCode}";
            _loggingService.Log(responseDetails);
        }
    }
}