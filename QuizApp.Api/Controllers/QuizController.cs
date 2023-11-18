using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Service.Quizservice;
using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Quiz>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            var response = await _quizService.GetAll(pageNumber, pageSize);
            return Ok(response);
        }
    }
}
