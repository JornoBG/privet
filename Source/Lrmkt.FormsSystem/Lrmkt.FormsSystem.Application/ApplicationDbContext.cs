using Lrmkt.FormsSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lrmkt.FormsSystem.Application
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Reaction> Reactions { get; set; }
    }
}
