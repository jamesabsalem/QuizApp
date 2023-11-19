using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Service.AuthService;
using QuizApp.Shared.Helper;
using QuizApp.Shared.Models.Dto;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous, HttpPost]
        public async Task<ActionResult<ServiceResponse<LoginResponseDTO>>> Login([FromBody] LoginRequestDTO loginRequest)
        {
            var response = await _authService.Login(loginRequest);
            return Ok(response);
        }
    }
}
