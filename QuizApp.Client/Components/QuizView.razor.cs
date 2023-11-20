using Microsoft.AspNetCore.Components;
using QuizApp.Client.Services;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Components
{
    public partial class QuizView
    {
        [Parameter]
        public Quiz Quiz { get; set; }
        public bool IsModalShow { get; set; } = false;
        public string _modalDisplay => IsModalShow ? "block" : "none";
        public List<Question> Questions { get; set; }
        public Question Question { get; set; }
        [Inject] public IHomeService HomeService { get; set; }
        private int QuestionIndex = 0;
        public void OnClickStartQuiz()
        {
           IsModalShow = true;
           
        }
        private void CloseModal()
        {
            IsModalShow = false;
            QuestionIndex = 0;
            StateHasChanged();
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
            if (QuestionIndex < Questions.Count)
            {
                QuestionIndex++;
                Question = Questions[QuestionIndex];
            }
        }
    }
}
