
namespace QuizApp.Shared.Models
{
    public class UserAnswer
    {
        public int UserAnswerId { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public int Point { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
