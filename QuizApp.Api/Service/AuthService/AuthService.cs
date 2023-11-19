using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Data;
using QuizApp.Api.Handler;
using QuizApp.Shared.Helper;
using QuizApp.Shared.Models.Dto;

namespace QuizApp.Api.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly JwtTokenHandler _jwtTokenHandler;

        public AuthService(ApplicationDbContext dbContext, JwtTokenHandler jwtTokenHandler)
        {
            _dbContext = dbContext;
            _jwtTokenHandler = jwtTokenHandler;
        }
        public async Task<ServiceResponse<LoginResponseDTO>> Login(LoginRequestDTO loginRequest)
        {
            var response = new ServiceResponse<LoginResponseDTO>();

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
                var loginResponse = new LoginResponseDTO
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
