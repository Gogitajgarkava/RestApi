using WebApplication1.Models;

namespace WebApplication1.Reqositories;

public interface IUserRepository
{
    Task<User?> CreateUserAsync(User user);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetUserByIdAsync(int id);
    Task<List<User>> GetAllAsync();
}
