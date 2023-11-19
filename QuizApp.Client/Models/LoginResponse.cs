namespace QuizApp.Client.Models
{
    public class LoginResponse
    {
        public Jwt JwtToken { get; set; }
        public User User { get; set; }
    }
}
