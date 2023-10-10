using Lrmkt.QuizzesSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lrmkt.QuizzesSystem.Application.ModelConfigurations
{
    public class OptionModelConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Options");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Text).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Choices).IsRequired();

            builder.HasOne(x => x.Question);
        }
    }
}
