using WebApplication1.Models;

namespace WebApplication1.DTOs.Responses
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
    }
}
