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
                .Where(q => q.IsPublished)
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

        public async Task<ServiceResponse<IEnumerable<Question>>> GetQuestions(int quizId)
        {
            var response = new ServiceResponse<IEnumerable<Question>>();
            try
            {

                var questions = await _dbContext.Questions
                    .Include(q => q.QuestionType)
                    .Include(q => q.Options)
                    .Where(q => q.QuizId == quizId)
                    .OrderBy(q => q.QuestionId)
                    .ToListAsync();

                if (questions == null || !questions.Any())
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    response.Message = ResponseMessage.DataLoaded;
                    response.Data = questions;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Quiz>>> GetQuizzesByUser(int userId)
        {
            var response = new ServiceResponse<IEnumerable<Quiz>>();
            try
            {

                var quizzes = await _dbContext.Quizzes
                .Include(q => q.User)
                .OrderByDescending(q => q.CreateDate)
                .Where(q => q.UserId == userId)
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
