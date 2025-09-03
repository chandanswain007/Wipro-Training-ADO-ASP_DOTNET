using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BookstoreApp.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, IHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            // Log the exception [cite: 40]
            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            // Create a user-friendly error response
            var result = new ViewResult { ViewName = "Error" };
            var modelMetadata = new EmptyModelMetadataProvider();
            result.ViewData = new ViewDataDictionary(modelMetadata, context.ModelState);
            result.ViewData.Add("Exception", context.Exception);

            if (!_hostEnvironment.IsDevelopment())
            {
                // In production, show a generic error message
                result.ViewData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
            }

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}