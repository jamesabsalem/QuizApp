using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Shared.Models.Dto
{
    public class JwtDTO
    {
        public string Toket {  get; set; }
        public int ExpiresIn {  get; set; }

    }
}
