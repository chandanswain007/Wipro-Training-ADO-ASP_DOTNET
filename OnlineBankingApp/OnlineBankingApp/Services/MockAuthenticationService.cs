using OnlineBankingApp.Models;
using System.Text.Json;

namespace OnlineBankingApp.Services
{
    public class MockAuthenticationService : IAuthenticationService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "jane.user", Role = "User" },
            new User { Id = 2, Username = "john.admin", Role = "Admin" }
        };

        public User Authenticate(string username)
        {
            return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public User GetCurrentUser(HttpContext context)
        {
            var userJson = context.Session.GetString("User");
            if (string.IsNullOrEmpty(userJson))
            {
                return null;
            }
            return JsonSerializer.Deserialize<User>(userJson);
        }
    }
}