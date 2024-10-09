using Microsoft.EntityFrameworkCore;
using ContentManagementAPI.Models;

namespace ContentManagementAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Content> Contents { get; set; }
        public DbSet<ApplicationUser> Users { get; set; } // Supondo que você tenha um modelo de usuário
    }
}