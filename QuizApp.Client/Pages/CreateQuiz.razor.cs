using ERP.Web.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using QuizApp.Client.Helper;
using QuizApp.Client.Services.HomeService;
using QuizApp.Shared.Models;
using QuizApp.Shared.Models.Dto;

namespace QuizApp.Client.Pages
{
    public partial class CreateQuiz
    {
        [Inject]public NavigationManager navigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] public IHomeService HomeService { get; set; }
        [Inject] IJSRuntime _jsRuntime { get; set; }
        private UserResponseDTO user = new();
        private Quiz quiz = new();
        private List<Quiz> quizzes = new();
        public async void OnClickAddQuiz()
        {
            var result = await HomeService.CreateQuiz(quiz);
            if(result.IsSuccess)
            {
                await _jsRuntime.ToastrSuccess(result.Message);
                navigationManager.NavigateTo("/CreateQuestion");
            }
            
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
