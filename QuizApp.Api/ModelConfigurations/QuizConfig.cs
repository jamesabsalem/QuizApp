using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Shared.Models;

namespace QuizApp.Api.ModelConfigurations
{
    public class QuizConfig : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable("Quiz");

            builder.HasKey(q => q.QuizId);

            builder.Property(q => q.QuizCode)
            .HasComputedColumnSql("CONCAT('QZ-', CONVERT(NVARCHAR(20), [QuizId]))")
            .IsRequired();

            builder.HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId);

            builder.Property(q => q.UserId).IsRequired();
            builder.Property(q => q.IsPublished).HasDefaultValue(false);
            builder.HasOne(q => q.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(q => q.Title).HasMaxLength(200).IsRequired();
            builder.Property(q => q.CreateDate).IsRequired();
        }
    }
}
