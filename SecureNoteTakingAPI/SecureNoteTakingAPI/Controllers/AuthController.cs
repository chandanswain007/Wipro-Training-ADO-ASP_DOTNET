using Microsoft.AspNetCore.Mvc;
using SecureNoteTakingAPI.DTO;
using SecureNoteTakingAPI.Service;

namespace SecureNoteTakingAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                await _authService.Register(registerDto);
                return Ok(new { message = "User registered successfully. Please log in." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var token = await _authService.Login(loginDto);
                return Ok(new LoginResponseDto
                {
                    Token = token,
                    ExpiresIn = 3600,
                    User = new UserResponseDto { Username = loginDto.Username }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
