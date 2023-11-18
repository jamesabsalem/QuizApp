using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> Register(User user);
    }
}
