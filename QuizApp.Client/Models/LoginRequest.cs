using System.ComponentModel.DataAnnotations;

namespace QuizApp.Client.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="Name is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Enter Password.")]
        public string Password { get; set; }
    }
}
