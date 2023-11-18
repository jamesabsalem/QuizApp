using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Service.RegistrationService
{
    public interface IRegistrationService
    {
        Task<ServiceResponse<User>> Create(User user);
    }
}
