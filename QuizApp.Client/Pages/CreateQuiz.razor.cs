using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizApp.Client.Helper;
using QuizApp.Client.Services.HomeService;
using QuizApp.Shared.Models;
using QuizApp.Shared.Models.Dto;

namespace QuizApp.Client.Pages
{
    public partial class CreateQuiz
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] public IHomeService HomeService { get; set; }
        private UserResponseDTO user = new();
        private List<Quiz> quizzes = new();
        public void OnClickAddQuiz()
        {
            navigationManager.NavigateTo("/CreateQuestion");
        }
        protected async override Task OnInitializedAsync()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)AuthenticationStateProvider;
            user = await customAuthStateProvider.GetAuthenticatedUser();
            if (user != null)
            {
                var result = await HomeService.GetQuizzesByUser(user.UserId);
                if (result.IsSuccess)
                {
                    quizzes = result.Data.ToList();
                }
            }
        }
    }
}
