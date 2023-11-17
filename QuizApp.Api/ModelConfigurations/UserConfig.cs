using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Shared.Models;

namespace QuizApp.Api.ModelConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(name: "User");

            builder.HasKey(u => u.UserId);

            builder.Property(u=> u.UserName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(20).IsRequired();

            builder.HasData(new User
            {
                UserId = 1,
                UserName="Admin",
                Email="admin@gmail.com",
                Password="Admin"
            });
        }
    }
}
