
namespace QuizApp.Shared.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsPublished { get; set; }
    }
}
