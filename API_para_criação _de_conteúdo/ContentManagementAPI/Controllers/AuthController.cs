using Microsoft.AspNetCore.Mvc;
using ContentManagementAPI.Services;
using ContentManagementAPI.Models;

namespace ContentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _authService.Authenticate(request.Username, request.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            var token = _authService.GenerateJwtToken(user);

            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
