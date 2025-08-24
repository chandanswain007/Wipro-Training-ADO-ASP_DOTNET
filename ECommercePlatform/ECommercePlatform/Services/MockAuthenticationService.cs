namespace ECommercePlatform.Services
{
    public class MockAuthenticationService : IAuthenticationService
    {
        public bool IsUserAuthenticated(HttpContext context)
        {
            // Check if a session variable "User" is set.
            // In a real app, this would involve checking tokens, cookies, etc.
            return !string.IsNullOrEmpty(context.Session.GetString("User"));
        }
    }
}