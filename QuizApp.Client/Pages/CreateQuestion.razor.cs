using QuizApp.Shared.Models;

namespace QuizApp.Client.Pages
{
    public partial class CreateQuestion
    {
        public List<Question> questions { get; set; } = new List<Question>();
        public void OnClickAddQuestion()
        {
            var question = new Question();
            questions.Add(question);
        }
    }
}
