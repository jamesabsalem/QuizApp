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
        public async Task<ServiceResponse<Pagination<Quiz>>> GetAll(int pageNumber, int pageSize)
        {
            var response = new ServiceResponse<Pagination<Quiz>>();
            try
            {
                var totalCount = await _dbContext.Quizzes.CountAsync();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var countries = await _dbContext.Quizzes
                    .Include(q => q.User)
                    .OrderByDescending(q => q.CreateDate)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                if (countries == null || !countries.Any())
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    response.Message = ResponseMessage.DataLoaded;
                    response.Data = new Pagination<Quiz>
                    {
                        Items = countries,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalItems = totalCount,
                        TotalPages = totalPages
                    };
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
