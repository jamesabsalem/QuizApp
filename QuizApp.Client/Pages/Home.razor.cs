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
    public partial class Home
    {
        [Inject] IJSRuntime _jsRuntime { get; set; }
        List<Quiz> QuizList;
        [Inject] public IHomeService HomeService { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private UserResponseDTO user = new();
        protected override async Task OnInitializedAsync()
        {
            var result = await HomeService.GetAll();
            if (result.IsSuccess)
            {
                QuizList = result.Data.ToList();
            }
            var customAuthStateProvider = (CustomAuthenticationStateProvider)AuthenticationStateProvider;
            user = await customAuthStateProvider.GetAuthenticatedUser();
        }
        
        private async Task onClick()
        {
            await _jsRuntime.ToastrSuccess("test");
        }
        
    }
}
