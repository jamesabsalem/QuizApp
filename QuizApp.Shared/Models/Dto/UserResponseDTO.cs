namespace QuizApp.Shared.Models.Dto
{
    public class UserResponseDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string JwtToken { get; set; }
    }
}
