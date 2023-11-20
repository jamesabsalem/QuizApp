using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;
using QuizApp.Shared.Models.Dto;
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

        public async Task<ServiceResponse<User>> SignUp(User user)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/User/SignUp", user);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<User>>(); ;
        }
        public async Task<ServiceResponse<UserResponseDTO>> SignIn(UserRequestDTO user)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/User/SignIn", user);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<UserResponseDTO>>(); ;
        }
    }
}
