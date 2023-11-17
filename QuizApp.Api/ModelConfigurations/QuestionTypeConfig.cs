using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Shared.Models;

namespace QuizApp.Api.ModelConfigurations
{
    public class QuestionTypeConfig : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.ToTable(name: "QuestionType", schema: "Quiz");

            builder.HasKey(q => q.QuestionTypeId);

            builder.Property(q => q.QuestionTypeName).HasMaxLength(10).IsRequired();

            builder.HasData(
                new QuestionType { QuestionTypeId = 1, QuestionTypeName = "Free Text" },
                new QuestionType { QuestionTypeId = 2, QuestionTypeName = "Multiple Choice" }
            );
        }
    }
}
