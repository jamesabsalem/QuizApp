using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Shared.Models
{
    public class UserAnswer
    {
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public int Point { get; set; }
    }
}
