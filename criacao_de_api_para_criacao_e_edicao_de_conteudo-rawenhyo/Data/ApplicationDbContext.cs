using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace YourNamespace.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<ContentSubmission> ContentSubmissions { get; set; }
        public DbSet<ContentReviewAssignment> ReviewAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentReviewAssignment>()
                .HasOne(c => c.ContentSubmission)
                .WithMany()
                .HasForeignKey(c => c.ContentId);

            modelBuilder.Entity<ContentReviewAssignment>()
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId);
        }
    }
}
