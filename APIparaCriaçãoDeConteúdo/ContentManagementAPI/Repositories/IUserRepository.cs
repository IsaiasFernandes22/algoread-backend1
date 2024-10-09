using System.Threading.Tasks;
using ContentManagementAPI.Models;

namespace ContentManagementAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
