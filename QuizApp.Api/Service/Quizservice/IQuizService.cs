using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Service.Quizservice
{
    public interface IQuizService
    {
        public Task<ServiceResponse<Pagination<Quiz>>> GetAll(int pageNumber, int pageSize);
    }
}
