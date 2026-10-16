using System.ComponentModel.DataAnnotations;
namespace WebApplication1.DTOs.Requests
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } 

        [Required]
        public string Password { get; set; }
    }
}
