using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Service.UserService;
using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

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
        public async Task<ActionResult<ServiceResponse<User>>> Register([FromBody]User user)
        {
            var response = await _userService.Register(user);
            return Ok(response);
        }
    }
}
