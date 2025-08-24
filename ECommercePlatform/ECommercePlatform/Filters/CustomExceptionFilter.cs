using ECommercePlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ECommercePlatform.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILoggingService _loggingService;

        public CustomExceptionFilter(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void OnException(ExceptionContext context)
        {
            // Log the exception details
            var errorMessage = $"Exception occurred: {context.Exception.Message}\nStackTrace: {context.Exception.StackTrace}";
            _loggingService.Log(errorMessage);

            // Set the result to the custom error view
            var result = new ViewResult { ViewName = "Error" };
            context.Result = result;

            // Mark the exception as handled
            context.ExceptionHandled = true;
        }
    }
}