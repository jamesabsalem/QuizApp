using QuizApp.Shared.Models;
using QuizApp.Shared.Helper;


namespace QuizApp.Shared.Service.RegistrationService
{
    public interface IRegistrationService
    {
        Task<ServiceResponse<User>> Create(User user);
    }
}
