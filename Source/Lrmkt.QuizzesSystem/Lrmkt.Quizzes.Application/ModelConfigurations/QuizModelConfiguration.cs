using Lrmkt.QuizzesSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lrmkt.QuizzesSystem.Application.ModelConfigurations
{
    public class QuizModelConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable("Quizzes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Answers).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

            builder.HasMany(x => x.Questions);
            builder.HasMany(x => x.Feedbacks);
        }
    }
}
