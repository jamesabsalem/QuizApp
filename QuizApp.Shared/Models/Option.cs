using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Shared.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public string OptionText { get; set; }
        public bool IsAnswer { get; set; }
    }
}
