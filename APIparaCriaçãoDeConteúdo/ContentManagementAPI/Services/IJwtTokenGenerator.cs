#nullable enable

using ContentManagementAPI.Models;

namespace ContentManagementAPI.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user); // Certifique-se de que User esteja definido corretamente
    }
}
