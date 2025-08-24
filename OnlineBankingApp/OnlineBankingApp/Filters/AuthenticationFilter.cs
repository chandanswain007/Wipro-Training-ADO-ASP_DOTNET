using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineBankingApp.Services;

namespace OnlineBankingApp.Filters
{
    public class AuthenticationFilter : IAuthorizationFilter
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationFilter(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = _authService.GetCurrentUser(context.HttpContext);
            if (user == null)
            {
                // Not logged in, redirect to login page.
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}