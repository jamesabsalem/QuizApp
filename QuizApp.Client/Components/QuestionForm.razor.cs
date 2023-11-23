using QuizApp.Shared.Models;

namespace QuizApp.Client.Components
{
    public partial class QuestionForm
    {
        public Question question = new();
        public Option option = new();
        private int QuestionType { get; set; } = 1;
    }
}
