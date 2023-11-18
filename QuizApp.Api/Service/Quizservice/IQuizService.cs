﻿using QuizApp.Shared.Helper;
using QuizApp.Shared.Models;

namespace QuizApp.Api.Service.Quizservice
{
    public interface IQuizService
    {
        public Task<ServiceResponse<IEnumerable<Quiz>>> GetAll();
    }
}
