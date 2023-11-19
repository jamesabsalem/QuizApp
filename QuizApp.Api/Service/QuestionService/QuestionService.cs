using QuizApp.Api.Data;
using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Service.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _dbContext;
        public QuestionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<Question>> Create(Question question)
        {
            var response = new ServiceResponse<Question>();
            try
            {
                question.CreateDate = DateTime.Now;
                _dbContext.Add(question);
                await _dbContext.SaveChangesAsync();
                response.Message = ResponseMessage.SaveSuccess;
                response.Data = question;
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
