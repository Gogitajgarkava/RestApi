using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Reqositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Baza _context;

        public UserRepository(Baza context)
        {
            _context = context;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new User
            {
                Id = user.Id,
                Username = user.Username,
            };
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
            
        }

        public Task<User?> GetUserByUsernameAsync(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            return Task.FromResult(user);
        }
    }
}
