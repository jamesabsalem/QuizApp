using ERP.Web.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QuizApp.Client.Services.HomeService;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Components
{
    public partial class QuizView
    {
        [Inject] IJSRuntime _jsRuntime { get; set; }
        [Inject] public IHomeService HomeService { get; set; }
        [Parameter]
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
        public List<Question> Questions { get; set; }
        public bool IsModalShow { get; set; } = false;
        public bool IsCongratulationsShow { get; set; } = false;
        private int ScoreCount { get; set; } = 0;
        public string _modalDisplay => IsModalShow ? "block" : "none";
        public string _CongratulationsModalDisplay => IsCongratulationsShow ? "block" : "none";

       
        private int QuestionIndex = 0;
        public async void OnClickStartQuiz()
        {
            if(Questions.Count>0)
            {
                IsModalShow = true;
                QuestionIndex = 0;
                Question = Questions[QuestionIndex];
                StateHasChanged();
               
            }
            else
            {
                await _jsRuntime.ToastrWarning("No Question Exist.");
            }
            
        }
        private void CloseModal()
        {
            IsModalShow = false;
        }
        protected async override Task OnInitializedAsync()
        {
            var result = await HomeService.GetQuestion(Quiz.QuizId);
            if (result.IsSuccess)
            {
                Questions = result.Data.ToList();
                Question = Questions[QuestionIndex];
            }
        }
        protected void OnClickNext()
        {
            QuestionIndex++;
            if (QuestionIndex < Questions.Count)
            {
                Question = Questions[QuestionIndex];
            }
            else
            {
                IsModalShow = false;
                IsCongratulationsShow = true;
                StateHasChanged();
            }
        }
        private void CloseCongratulationsModal()
        {
            IsCongratulationsShow = false;
        }
    }
}
