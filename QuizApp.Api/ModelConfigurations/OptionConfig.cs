using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Shared.Models;

namespace QuizApp.Api.ModelConfigurations
{
    public class OptionConfig : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable(name: "Option", schema: "Quiz");

            builder.HasKey(q => q.OptionId);

            builder.Property(q=>q.OptionText).HasMaxLength(100).IsRequired();
            builder.Property(q=>q.IsAnswer).IsRequired();
        }
    }
}
