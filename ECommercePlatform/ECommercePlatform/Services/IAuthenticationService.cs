namespace ECommercePlatform.Services
{
    public interface IAuthenticationService
    {
        bool IsUserAuthenticated(HttpContext context);
    }
}