using Lrmkt.CourseRatings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lrmkt.CourseRatings.Application.ModelConfigurations
{
    public class QuestionModelConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Text).IsRequired().HasMaxLength(500);

            builder.HasOne(x => x.Course);
            builder.HasMany(x => x.Raitings);
        }
    }
}
