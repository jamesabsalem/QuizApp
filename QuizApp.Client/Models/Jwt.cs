namespace QuizApp.Client.Models
{
    public class Jwt
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime ExpiryTimeStamp { get; set; }
    }
}
