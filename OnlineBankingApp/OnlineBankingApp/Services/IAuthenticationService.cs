using OnlineBankingApp.Models;

namespace OnlineBankingApp.Services
{
    public interface IAuthenticationService
    {
        User Authenticate(string username);
        User GetCurrentUser(HttpContext context);
    }
}