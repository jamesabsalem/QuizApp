using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Service.UserService;
using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;
using QuizApp.Shared.Models.Dto;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<User>>> SignUp([FromBody]User user)
        {
            var response = await _userService.SignUp(user);
            return Ok(response);
        }
        [AllowAnonymous, HttpPost]
        public async Task<ActionResult<ServiceResponse<UserResponseDTO>>> SignIn([FromBody] UserRequestDTO loginRequest)
        {
            var response = await _userService.SignIn(loginRequest);
            return Ok(response);
        }
    }
}
