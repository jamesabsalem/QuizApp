using ERP.Web.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QuizApp.Client.Services.UserService;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Pages
{
    public partial class SignUp
    {
        [Inject] IJSRuntime _jsRuntime { get; set; }
        private User user = new User();
        [Inject]public IUserService UserService { get; set; }
        private async Task UserRegistration()
        {
            await _jsRuntime.ToastrSuccess("test");
        }

    }
}
