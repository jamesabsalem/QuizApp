using ERP.Web.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QuizApp.Client.Services;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Pages
{
    public partial class Home
    {
        [Inject] IJSRuntime _jsRuntime { get; set; }
        List<Quiz> QuizList;
        private string _modalDisplay = "none";
        [Inject] public IHomeService HomeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await HomeService.GetAll();
            if (result.IsSuccess)
            {
                QuizList = result.Data.ToList();
            }
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
}
