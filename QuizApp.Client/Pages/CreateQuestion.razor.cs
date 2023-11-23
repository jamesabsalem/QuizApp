using Microsoft.AspNetCore.Components;
using QuizApp.Client.Services.HomeService;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Pages
{
    public partial class CreateQuestion
    {
        [Parameter]
        public string quizId { get; set; }
        [Inject] public IHomeService HomeService { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }
        public List<Question> questions { get; set; } = new List<Question>();
        public void OnClickAddQuestion()
        {
            var question = new Question();
            questions.Add(question);
        }
       
    }
}
