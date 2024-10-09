// C:\algoread-backend1\APIparaCriaçãoDeConteúdo\ContentManagementAPI\Repositories\IUserRepository.cs
using System.Threading.Tasks;
using ContentManagementAPI.Models;

namespace ContentManagementAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
        Task AddUser(User user);
    }
}
