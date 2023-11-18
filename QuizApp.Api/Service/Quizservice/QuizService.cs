using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Data;
using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Service.Quizservice
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext _dbContext;
        public QuizService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServiceResponse<IEnumerable<Quiz>>> GetAll()
        {
            var response = new ServiceResponse<IEnumerable<Quiz>>();
            try
            {

                var quizzes = await _dbContext.Quizzes
                .Include(q => q.User)
                //.Include(q => q.Questions)
                //.ThenInclude(q => q.QuestionType)
                .OrderByDescending(q => q.CreateDate)
                .ToListAsync();


                if (quizzes == null || !quizzes.Any())
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    response.Message = ResponseMessage.DataLoaded;
                    response.Data = quizzes;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
