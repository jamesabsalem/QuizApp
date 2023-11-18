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
        private async Task UserRegistration()
        {
            //var result = await UserService.Register(user);
            await _jsRuntime.ToastrSuccess("User registered successfully!");
            NavigationManager.NavigateTo("/SignIn");
            user = new User();
        }

    }
}
