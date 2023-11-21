using ERP.Web.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using QuizApp.Client.Helper;
using QuizApp.Client.Services.HomeService;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Pages
{
    public partial class Home
    {
        [Inject] IJSRuntime _jsRuntime { get; set; }
        List<Quiz> QuizList;
        [Inject] public IHomeService HomeService { get; set; }
        [Inject] public AuthenticationStateProvider authenticationStateProvider { get; set; }
        private string username;
        protected override async Task OnInitializedAsync()
        {
            var result = await HomeService.GetAll();
            if (result.IsSuccess)
            {
                QuizList = result.Data.ToList();
            }
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                username = user.Identity.Name;
            }
        }
        
        private async Task onClick()
        {
            await _jsRuntime.ToastrSuccess("test");
        }
        
    }
}
