using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Shared.Helper
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
