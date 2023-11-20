using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Data;
using QuizApp.Api.Handler;
using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;
using QuizApp.Shared.Models.Dto;

namespace QuizApp.Api.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly JwtTokenHandler _jwtTokenHandler;
        public UserService(ApplicationDbContext dbContext, JwtTokenHandler jwtTokenHandler)
        {
            _dbContext = dbContext;
            _jwtTokenHandler = jwtTokenHandler;
        }
        public async Task<ServiceResponse<User>> SignUp(User user)
        {
            var responce = new ServiceResponse<User>();
            try
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();

                responce.Message = ResponseMessage.SaveSuccess;
                responce.Data = user;
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
        public async Task<ServiceResponse<UserResponseDTO>> SignIn(UserRequestDTO loginRequest)
        {
            var response = new ServiceResponse<UserResponseDTO>();

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password);

            if (user == null)
            {
                response.IsSuccess = false;
                response.Message = ResponseMessage.InvalidUser;
            }
            else
            {
                var jwt = _jwtTokenHandler.GenerateJwtToken(loginRequest.UserName);
                var loginResponse = new UserResponseDTO
                {
                    JwtToken = jwt,
                    UserId = user.UserId,
                    UserName = user.UserName
                };
                response.Data = loginResponse;
                response.Message = ResponseMessage.LoginSuccess;
            }

            return response;
        }

    }
}
