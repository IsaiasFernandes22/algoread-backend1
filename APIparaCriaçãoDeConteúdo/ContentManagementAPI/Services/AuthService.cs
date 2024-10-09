// C:\algoread-backend1\APIparaCriaçãoDeConteúdo\ContentManagementAPI\Services\AuthService.cs
using System.Threading.Tasks;
using ContentManagementAPI.DTOs;
using ContentManagementAPI.Repositories;
using ContentManagementAPI.Models;

namespace ContentManagementAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByUsername(loginDto.Username);
            if (user == null || user.Password != loginDto.Password)
            {
                return null;
            }

            return new LoginResponseDto
            {
                Username = user.Username,
                Token = GenerateToken(user)
            };
        }

        public async Task RegisterAsync(RegisterDto registerDto)
        {
            var newUser = new User
            {
                Username = registerDto.Username,
                Password = registerDto.Password
            };

            await _userRepository.AddUser(newUser);
        }

        private string GenerateToken(User user)
        {
            // Lógica para gerar o token JWT
            return "token";
        }
    }
}
