// C:\algoread-backend1\APIparaCriaçãoDeConteúdo\ContentManagementAPI\Services\IAuthService.cs
using System.Threading.Tasks;
using ContentManagementAPI.DTOs;

namespace ContentManagementAPI.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        Task RegisterAsync(RegisterDto registerDto);
    }
}
