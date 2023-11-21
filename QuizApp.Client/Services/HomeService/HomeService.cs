using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;
using System.Net.Http.Json;

namespace QuizApp.Client.Services.HomeService
{
    public class HomeService : IHomeService
    {
        private readonly HttpClient _httpClient;

        public HomeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ServiceResponse<IEnumerable<Quiz>>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<Quiz>>>($"api/Quiz/GetAll");
        }

        public async Task<ServiceResponse<IEnumerable<Question>>> GetQuestion(int quizId)
        {
            var response = await _httpClient.GetAsync($"api/Quiz/GetQuestions?quizId={quizId}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<IEnumerable<Question>>>();
        }

        public async Task<ServiceResponse<IEnumerable<Quiz>>> GetQuizzesByUser(int userId)
        {
            var response = await _httpClient.GetAsync($"api/Quiz/GetQuizzesByUser?userId={userId}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<IEnumerable<Quiz>>>();
        }
    }
}
