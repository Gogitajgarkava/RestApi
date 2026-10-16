namespace WebApplication1.DTOs.Responses
{
    public class LoginUserResponseDto
    {
        public string AuthToken { get; set; }
        public int ExpiresIn { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}
