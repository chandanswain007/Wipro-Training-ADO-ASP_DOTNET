using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineBankingApp.Services;

namespace OnlineBankingApp.Filters
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
            _loggingService.Log($"ERROR: {context.Exception.Message}\nSTACKTRACE: {context.Exception.StackTrace}");
            context.Result = new ViewResult { ViewName = "Error" };
            context.ExceptionHandled = true;
        }
    }
}