using ERP.Web.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QuizApp.Client.Services.UserService;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Pages
{
    public partial class SignUp
    {
        private User user = new User();
        [Inject] IJSRuntime _jsRuntime { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] public IUserService UserService { get; set; }
        private async Task UserSignUp()
        {
            var result = await UserService.Register(user);
            if(result.IsSuccess)
            {
                await _jsRuntime.ToastrSuccess(result.Message);
                var user = result.Data;
                NavigationManager.NavigateTo("/SignIn");
            }
          
        }

    }
}
