using Microsoft.AspNetCore.Components;

namespace QuizApp.Client.Pages
{
    public partial class CreateQuiz
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public void OnClickAddQuiz()
        {
            navigationManager.NavigateTo("/CreateQuestion");
        }
    }
}
