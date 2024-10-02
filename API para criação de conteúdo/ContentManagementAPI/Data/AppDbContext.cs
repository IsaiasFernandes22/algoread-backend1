using Microsoft.EntityFrameworkCore;
using ContentManagementAPI.Models; 

namespace ContentManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Content> Contents { get; set; } 
    }
}
