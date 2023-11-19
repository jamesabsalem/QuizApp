using ERP.Web.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QuizApp.Client.Models;
using QuizApp.Client.Services.AuthService;

namespace QuizApp.Client.Pages
{
    public partial class SignIn
    {
        // service
        [Inject] IAuthService AuthService { get; set; }
        [Inject] IJSRuntime _JsRuntime { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        // variable
        private LoginRequest loginRequest = new LoginRequest();
        private async Task OnClickLogin()
        {
            var result = await AuthService.Login(loginRequest);
            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo("/dashboard");
                await _JsRuntime.ToastrSuccess(result.Message);
            }
            else
            {
                await _JsRuntime.ToastrError(result.Message);
            }
        }
    }
}
