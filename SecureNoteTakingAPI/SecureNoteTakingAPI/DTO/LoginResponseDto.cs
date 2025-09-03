namespace SecureNoteTakingAPI.DTO
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
        public UserResponseDto User { get; set; } = new UserResponseDto();
    }

    public class UserResponseDto
    {
        public string Username { get; set; } = string.Empty;
    }
}
