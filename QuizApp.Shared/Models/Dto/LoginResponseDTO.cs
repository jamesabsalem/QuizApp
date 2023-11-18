using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Shared.Models.Dto
{
    public class LoginResponseDTO
    {
        public JwtDTO JwtToken {  get; set; }
        public UserDTO User {  get; set; }

    }
}
