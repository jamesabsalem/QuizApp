using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Shared.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public int QuestionTypeId { get; set; }
        public string QuestionText { get; set; }
        public string Url { get; set; }
        public int TimeLemit { get; set; }
        public int Point { get; set; }
    }
}
