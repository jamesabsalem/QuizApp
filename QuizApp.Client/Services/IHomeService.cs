using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Services
{
    public interface IHomeService
    {
        Task<ServiceResponse<IEnumerable<Quiz>>> GetAll();
    }
}
