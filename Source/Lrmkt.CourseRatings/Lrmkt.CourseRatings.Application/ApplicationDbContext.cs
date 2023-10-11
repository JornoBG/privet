using Lrmkt.CourseRatings.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lrmkt.CourseRatings.Application
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Course> Courses { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Rating> Raitings { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
