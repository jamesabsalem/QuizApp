﻿using QuizApp.Api.Data;
using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Service.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDbContext _dbContext;
        public RegistrationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServiceResponse<User>> Create(User user)
        {
            var responce = new ServiceResponse<User>();
            try
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();

                responce.Message = ResponseMessage.SaveSuccess;
                responce.Data = user;
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

    }
}