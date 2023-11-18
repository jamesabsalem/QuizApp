using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Shared.Models;

namespace QuizApp.Api.ModelConfigurations
{
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");

            builder.HasKey(q => q.QuestionId);

            builder.Property(q => q.QuizId).IsRequired();
            builder.HasOne(q => q.Quiz)
                .WithMany(q => q.Questions)
                .HasForeignKey(u => u.QuizId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(q => q.QuestionTypeId).IsRequired();
            builder.HasOne(q => q.QuestionType)
                .WithMany()
                .HasForeignKey(u => u.QuestionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(q => q.QuestionText).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Point).IsRequired();
            builder.Property(q => q.CreateBy).IsRequired();
            builder.Property(q => q.CreateDate).IsRequired();
        }
    }
}
