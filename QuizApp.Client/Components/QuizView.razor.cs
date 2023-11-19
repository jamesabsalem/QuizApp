using Microsoft.AspNetCore.Components;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Components
{
    public partial class QuizView
    {
        [Parameter]
        public Quiz Quiz { get; set; }
        public bool IsModalShow { get; set; } = false;
        public string _modalDisplay => IsModalShow ? "block" : "none";
        public void OnClickStartQuiz()
        {
           IsModalShow = true;
        }
        private void CloseModal()
        {
            IsModalShow = false;
        }
    }
}
