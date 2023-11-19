using QuizApp.Client.Models;
using QuizApp.Shared.Helper;

namespace QuizApp.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<LoginResponse>> Login(LoginRequest request);
    }
}
