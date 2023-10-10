using Lrmkt.QuizzesSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lrmkt.QuizzesSystem.Application.ModelConfigurations
{
    public class QuestionModelConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Text).IsRequired().HasMaxLength(500);

            builder.HasOne(x => x.Quiz);
            builder.HasMany(x => x.Options);
        }
    }
}
