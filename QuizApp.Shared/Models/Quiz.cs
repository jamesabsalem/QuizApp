
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Shared.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        [NotMapped]
        public string QuizCode => $"QZ-{QuizId}";
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsPublished { get; set; }
        public List<Question> Questions { get; set; }
    }
}
