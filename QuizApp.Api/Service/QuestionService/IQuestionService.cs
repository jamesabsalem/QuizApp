using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Service.QuestionService
{
    public interface IQuestionService
    {
        Task<ServiceResponse<Question>> Create(Question question);
    }
}
