// C:\algoread-backend1\APIparaCriaçãoDeConteúdo\ContentManagementAPI\Repositories\UserRepository.cs
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContentManagementAPI.Models;
using ContentManagementAPI.Data;

namespace ContentManagementAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
