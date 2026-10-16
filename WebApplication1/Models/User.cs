using WebApplication1.CORE;

namespace WebApplication1.Models;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; }


}
