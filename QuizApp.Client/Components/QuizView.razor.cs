using Microsoft.AspNetCore.Components;
using QuizApp.Client.Services.HomeService;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Components
{
    public partial class QuizView
    {
        [Parameter]
        public Quiz Quiz { get; set; }
        public bool IsModalShow { get; set; } = false;
        public bool IsCongratulationsShow { get; set; } = false;
        public string _modalDisplay => IsModalShow ? "block" : "none";
        public string _CongratulationsModalDisplay => IsCongratulationsShow ? "block" : "none";
        public List<Question> Questions { get; set; }
        public Question Question { get; set; }
        [Inject] public IHomeService HomeService { get; set; }
        private int QuestionIndex = 0;
        public void OnClickStartQuiz()
        {
            IsModalShow = true;
            QuestionIndex = 0;
            Question = Questions[QuestionIndex];
            StateHasChanged();
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
