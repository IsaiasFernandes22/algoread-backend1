using Microsoft.EntityFrameworkCore;
using NomeDoProjeto.Models;

namespace NomeDoProjeto.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Content> Contents { get; set; }
    }
}
