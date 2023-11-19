using QuizApp.Client.Models;
using QuizApp.Shared.Helper;
using System.Net.Http.Json;

namespace QuizApp.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        public AuthService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<LoginResponse>> Login(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync($"api/auth/login", request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<LoginResponse>>();
        }
    }
}
