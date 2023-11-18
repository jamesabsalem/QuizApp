using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Service.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> Register(User user);
    }
}
