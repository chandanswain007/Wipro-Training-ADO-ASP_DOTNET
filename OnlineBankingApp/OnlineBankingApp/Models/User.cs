namespace OnlineBankingApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } // e.g., "User", "Admin"
    }
}