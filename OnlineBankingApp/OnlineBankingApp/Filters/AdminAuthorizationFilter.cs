using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineBankingApp.Services;

namespace OnlineBankingApp.Filters
{
    public class AdminAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IAuthenticationService _authService;

        public AdminAuthorizationFilter(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = _authService.GetCurrentUser(context.HttpContext);

            // User must be logged in AND have the "Admin" role.
            if (user == null || !user.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                // User is not authorized, so return a "Forbidden" response.
                context.Result = new ForbidResult();
            }
        }
    }
}