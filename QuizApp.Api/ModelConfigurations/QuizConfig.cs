using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Shared.Models;

namespace QuizApp.Api.ModelConfigurations
{
    public class QuizConfig : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable(name: "Quiz");

            builder.HasKey(q => q.QuizId);

            builder.Property(q => q.UserId).IsRequired();
            builder.HasOne(q => q.User)
               .WithMany()
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.Restrict)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(q => q.Title).HasMaxLength(200).IsRequired();
            builder.Property(q => q.CreateDate).IsRequired();
        }
    }
}
