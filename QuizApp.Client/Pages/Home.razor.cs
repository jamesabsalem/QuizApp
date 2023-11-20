using ERP.Web.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QuizApp.Client.Services.HomeService;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Pages
{
    public partial class Home
    {
        [Inject] IJSRuntime _jsRuntime { get; set; }
        List<Quiz> QuizList;
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
        
    }
}
