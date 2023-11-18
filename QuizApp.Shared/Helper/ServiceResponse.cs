namespace QuizApp.Shared.Helper
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
