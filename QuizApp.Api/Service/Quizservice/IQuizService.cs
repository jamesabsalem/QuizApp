using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Service.Quizservice
{
    public interface IQuizService
    {
        public Task<ServiceResponse<IEnumerable<Quiz>>> GetAll();
        public Task<ServiceResponse<IEnumerable<Question>>> GetQuestions(int quizId);
        public Task<ServiceResponse<IEnumerable<Quiz>>> GetQuizzesByUser(int userId);
        public Task<ServiceResponse<Quiz>> QuizPublished(int quizId);
        public Task<ServiceResponse<Quiz>> CreateQuize(Quiz quiz);
        Task<ServiceResponse<Question>> CreateQuestion(Question question);
    }
}
