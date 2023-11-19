using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;
using System.Net.Http.Json;

namespace QuizApp.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<User>> Register(User user)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/User/Register", user);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<User>>(); ;
        }
    }
}
