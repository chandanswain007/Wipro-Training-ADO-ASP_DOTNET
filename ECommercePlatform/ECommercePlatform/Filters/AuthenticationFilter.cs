using ECommercePlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommercePlatform.Filters
{
    public class AuthenticationFilter : IAuthorizationFilter
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationFilter(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_authenticationService.IsUserAuthenticated(context.HttpContext))
            {
                // If the user is not authenticated, redirect to the Login page.
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}