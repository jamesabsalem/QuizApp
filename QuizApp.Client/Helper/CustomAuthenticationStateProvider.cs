using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using QuizApp.Shared.Models.Dto;

namespace QuizApp.Client.Helper
{

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await _sessionStorage.GetItemAsync<UserResponseDTO>("UserSession");
            if (user != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name,user.UserName),
            }, "custom");

                var claimsPrincipal = new ClaimsPrincipal(identity);
                var authState = new AuthenticationState(claimsPrincipal);
                NotifyAuthenticationStateChanged(Task.FromResult(authState));
                return authState;
            }
            else
            {
                return new AuthenticationState(_anonymous);
            }
        }

        public async Task UpdateAuthenticationState(UserResponseDTO userResponse)
        {
            ClaimsPrincipal claimsPrincipal;
            if (userResponse != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userResponse.UserName)
                }));
                await _sessionStorage.SetItemAsync("UserSession", userResponse);
            }
            else
            {
                claimsPrincipal = _anonymous;
                await _sessionStorage.RemoveItemAsync("UserSession");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
        public async Task<UserResponseDTO> GetAuthenticatedUser()
        {
            UserResponseDTO userResponse;
            try
            {
                userResponse = await _sessionStorage.GetItemAsync<UserResponseDTO>("UserSession");
                return userResponse;
            }
            catch
            {
               return new UserResponseDTO();
            }
        }

        public async Task MarkUserAsSignOut()
        {
            await _sessionStorage.RemoveItemAsync("UserSession");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        }
    }

}
