using QuizApp.Shared.Helper;
using QuizApp.Shared.Models.Dto;

namespace QuizApp.Api.Service.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<LoginResponseDTO>> Login(LoginRequestDTO loginRequest);
    }
}
