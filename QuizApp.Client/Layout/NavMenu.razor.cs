using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizApp.Client.Helper;
namespace QuizApp.Client.Layout
{
    public partial class NavMenu
    {
        [Inject] AuthenticationStateProvider autherStateProvider { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }
        public async Task OnClickSignOut()
        {
            var customAuthenticationState = (CustomAuthenticationStateProvider)autherStateProvider;
            await customAuthenticationState.MarkUserAsSignOut();
            navigationManager.NavigateTo("");
        }
        public void OnClickSignIn()
        {
            navigationManager.NavigateTo("/SignIn");
        }
    }
}
