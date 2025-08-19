// In SecureApp/UserService.cs
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SecureAppl
{
    public class UserService
    {
        private readonly Dictionary<string, User> _users = new Dictionary<string, User>();

        public ILogger Log { get; } = Logger.GetLogger();

        public User Register(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new ArgumentException("Username or password cannot be empty.");
                }
                if (_users.ContainsKey(username))
            {
                throw new ArgumentException("Username already exists.");
            }

            var user = new User(username);
            user.HashedPassword=this.HashPassword(password); // Using a helper method to set password
            _users.Add(username, user);
            Log.Information("User {Username} registered successfully.", username);
                return user;
            }
            catch (ArgumentException ex)
            {
                Log.Warning("Registration failed: {Message}", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error registering user {Username}.", username);
                throw;
            }
            
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Add this method to SecureApp/UserService.cs
        public bool Authenticate(string username, string password)
        {
            if (!_users.ContainsKey(username))
            {
                return false;
            }

            var user = _users[username];
            var hashedPassword = HashPassword(password);
            return user.HashedPassword == hashedPassword;
        }
    }


    // Add this method inside the User class
    public partial class User
    {
        public void SetPassword(string password, UserService service)
        {
            HashedPassword = service.HashPassword(password);
        }
    }
}