using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;
using QuizApp.Shared.Models.Dto;

namespace QuizApp.Client.Services.UserService
{
    public interface IUserService
    {
        public Task<ServiceResponse<User>> SignUp(User user);
        public Task<ServiceResponse<UserResponseDTO>> SignIn(UserRequestDTO request);
    }
}
