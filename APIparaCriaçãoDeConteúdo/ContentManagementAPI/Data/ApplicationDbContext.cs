// C:\algoread-backend1\APIparaCriaçãoDeConteúdo\ContentManagementAPI\Data\ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using ContentManagementAPI.Models;

namespace ContentManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Content> Contents { get; set; }
    }
}
