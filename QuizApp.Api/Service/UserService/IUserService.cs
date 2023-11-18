﻿using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Service.UserService
{
    public interface IUserService
    {
        public Task<ServiceResponse<User>> Register(User user);
    }
}
