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
        public async Task<ActionResult<ServiceResponse<Quiz>>> GetAll()
        {
            var response = await _quizService.GetAll();
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Question>>> GetQuestions(int quizId)
        {
            var response = await _quizService.GetQuestions(quizId);
            return Ok(response);
        }
    }
}
