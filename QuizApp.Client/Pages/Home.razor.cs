using ERP.Web.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace QuizApp.Client.Pages
{
    public partial class Home
    {
        [Inject] IJSRuntime _jsRuntime { get; set; }
        List<Quiz> QuizList;
        private string _modalDisplay = "none";
        protected override void OnInitialized()
        {
            QuizList = new List<Quiz>()
           {
                new Quiz(){ QuizId = 1,QuizCode="XX01",QuizTitle="C#"},
                new Quiz(){ QuizId = 2,QuizCode="XX02",QuizTitle="Java"},
                new Quiz(){ QuizId = 3,QuizCode="XX03",QuizTitle="Type Script"},
                new Quiz(){ QuizId = 4,QuizCode="XX04",QuizTitle=".Net"},
                new Quiz(){ QuizId = 5,QuizCode="XX05",QuizTitle="Jquery"},
                new Quiz(){ QuizId = 6,QuizCode="XX06",QuizTitle="Java Script"},
                new Quiz(){ QuizId = 7,QuizCode="XX07",QuizTitle="Python"},
                new Quiz(){ QuizId = 8,QuizCode="XX08",QuizTitle="SQL"},
                new Quiz(){ QuizId = 9,QuizCode="XX09",QuizTitle="Rust"},
                new Quiz(){ QuizId = 10,QuizCode="XX010",QuizTitle="Objective - C"}
           };
        }
        private async Task onClick()
        {
            await _jsRuntime.ToastrSuccess("test");
        }
        public void OnClickStartQuiz()
        {
            ModelDisplay(true);
        }
        private void OnClickClose()
        {
            ModelDisplay(false);
        }

        private void ModelDisplay(bool isShow)
        {
            _modalDisplay = isShow ? "block" : "none";
        }
    }

    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizCode { get; set; }
        public string QuizTitle { get; set; }

    }

}
