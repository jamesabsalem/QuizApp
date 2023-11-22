using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Services.HomeService
{
    public interface IHomeService
    {
        Task<ServiceResponse<IEnumerable<Quiz>>> GetAll();
        Task<ServiceResponse<IEnumerable<Question>>> GetQuestion(int quizId);
        Task<ServiceResponse<IEnumerable<Quiz>>> GetQuizzesByUser(int userId);
        Task<ServiceResponse<Quiz>> CreateQuiz(Quiz quiz);
        Task<ServiceResponse<Quiz>> QuizPublished(int quizId);
    }
}
