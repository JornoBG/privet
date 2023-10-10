using Lrmkt.QuizzesSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lrmkt.QuizzesSystem.Application.ModelConfigurations
{
    public class FeedbackModelConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.Quiz);
        }
    }
}
