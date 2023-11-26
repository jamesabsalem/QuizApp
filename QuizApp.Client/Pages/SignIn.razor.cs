using ERP.Web.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using QuizApp.Client.Helper;
using QuizApp.Client.Services.UserService;
using QuizApp.Shared.Models.Dto;

namespace QuizApp.Client.Pages
{
    public partial class SignIn
    {
        [Inject] IJSRuntime _JsRuntime { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IUserService UserService { get; set; }
        [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private UserRequestDTO userRequest = new UserRequestDTO();
        private async Task OnClickSignIn()
        {
            var result = await UserService.SignIn(userRequest);
            if (result.IsSuccess)
            {
                var customAuthStateProvider = (CustomAuthenticationStateProvider)AuthenticationStateProvider;
                await customAuthStateProvider.UpdateAuthenticationState(result.Data);
                NavigationManager.NavigateTo("/",forceLoad:true);
                await _JsRuntime.ToastrSuccess(result.Message);
            }
            else
            {
                await _JsRuntime.ToastrError(result.Message);
            }
        }
    }
}
