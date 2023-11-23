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
        private Quiz quizEntry = new();
        private List<Quiz> quizzes = new();
        public async void OnClickAddQuiz()
        {
            quizEntry.UserId = user.UserId;
            var result = await HomeService.CreateQuiz(quizEntry);
            if (result.IsSuccess)
            {
                quizEntry.Title = string.Empty;
                await _jsRuntime.ToastrSuccess(result.Message);
                var quizId = result.Data.QuizId;
                navigationManager.NavigateTo($"/CreateQuestion?quizId={quizId}");
            }
        }
        protected async override Task OnInitializedAsync()
        {
            await BindTable();
        }
        private async Task BindTable()
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
        public async Task OnClickPublished(int quizId)
        {
            var result = await HomeService.QuizPublished(quizId);
            if(result.IsSuccess)
            {
                await _jsRuntime.ToastrSuccess(result.Message);
                await BindTable();
            }
        }
        public async void OnClickAddQuestion(int quizId)
        {
            var result = await HomeService.QuizPublished(quizId);
            if(result.IsSuccess)
            {
                Console.WriteLine(result.Data.QuizId);
                navigationManager.NavigateTo($"/CreateQuestion?quizId={quizId}");
            }
        }
    }
}
