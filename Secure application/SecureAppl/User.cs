// In SecureApp/User.cs
using System;
using System.Security.Cryptography;
using System.Text;

namespace SecureAppl
{
    public partial class User
    {
        public string Username { get; private set; }
        public string HashedPassword { get; set; }

        public User(string username)
        {
            Username = username;
        }
    }
}