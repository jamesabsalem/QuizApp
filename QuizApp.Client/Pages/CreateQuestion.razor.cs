using Microsoft.AspNetCore.Components;
using QuizApp.Client.Services.HomeService;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Pages
{
    public partial class CreateQuestion
    {
        [Inject] public IHomeService HomeService { get; set; }
        public List<Question> questions { get; set; } = new List<Question>();
        [Parameter] public int QuizId { get; set; }
        public void OnClickAddQuestion()
        {
            var question = new Question();
            questions.Add(question);
        }
        
    }
}
