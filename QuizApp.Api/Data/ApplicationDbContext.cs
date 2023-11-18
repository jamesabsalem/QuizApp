using Microsoft.EntityFrameworkCore;
using QuizApp.Api.ModelConfigurations;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new QuestionTypeConfig());
            modelBuilder.ApplyConfiguration(new QuizConfig());
            modelBuilder.ApplyConfiguration(new OptionConfig());
            modelBuilder.ApplyConfiguration(new QuestionConfig());
            modelBuilder.ApplyConfiguration(new UserAnswerConfig());
        }
    }
}
