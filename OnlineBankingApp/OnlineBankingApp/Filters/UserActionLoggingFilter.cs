using Microsoft.AspNetCore.Mvc.Filters;
using OnlineBankingApp.Services;

namespace OnlineBankingApp.Filters
{
    public class UserActionLoggingFilter : IActionFilter
    {
        private readonly ILoggingService _loggingService;
        private readonly IAuthenticationService _authService;

        public UserActionLoggingFilter(ILoggingService loggingService, IAuthenticationService authService)
        {
            _loggingService = loggingService;
            _authService = authService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = _authService.GetCurrentUser(context.HttpContext);
            var userName = user?.Username ?? "Anonymous";

            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            _loggingService.Log($"User '{userName}' is attempting to access {controllerName}/{actionName}.");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // This can be used to log the result of the action, e.g., success or failure
        }
    }
}