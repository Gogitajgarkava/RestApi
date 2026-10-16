using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Reqositories;
using WebApplication1.Security;

namespace WebApplication1.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;
    private readonly TokenGenerator _tokenGenerator;

    public UserServices(IUserRepository userRepository, TokenGenerator tokenGenerator   )
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<(string? error, UserResponseDto? result)> CreateUserAsync(CreateUserDto request)
    {
        var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
        if (existingUser != null)
        {
            return ("მომხმარებელი აღნიშნული Username-ით უკვე არსებობს", null);
        }

        var newUser = new User
        {
            Username = request.Username,
            Role = UserRole.User,
            PasswordHash = PasswordHasher.HashPassword(request.Password),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _userRepository.CreateUserAsync(newUser);

        var response = new UserResponseDto
        {
            Id = newUser.Id,
            Username = newUser.Username,
            Role = newUser.Role
        };

        return (null, response);
    }

    public async Task<(string? error, List<UserResponseDto>? response)> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        var response = users.Select(u => new UserResponseDto
        {
            Id = u.Id,
            Username = u.Username,
            Role = u.Role
        }).ToList();

        return (null, response);
    }

    public async Task<UserResponseDto> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null) 
        {
            return null;
        }

        return new UserResponseDto 
        { 
            Id = user.Id,
            Username = user.Username,
            Role = user.Role
        };
        
    }

    public async Task<UserResponseDto?> GetUserByUserameAsync(string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);

        if (user == null)
        {
            return null;
        }

        return new UserResponseDto
        {
            Id = user.Id,
            Username = user.Username,
            Role = user.Role
        };
    }

    

    public async Task<(string Error, LoginUserResponseDto)> LoginUserAsync(LoginUserDto dto)
    {
        var user =  await _userRepository.GetUserByUsernameAsync(dto.Username);
        if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
        {
            return ("Invalid username or password.", null);
        }

        var authToken = _tokenGenerator.GenerateToken(user);



        var response = new LoginUserResponseDto
        {
            AuthToken = authToken,
            ExpiresIn = 3600, 
            UserId = user.Id,
           
        };

        return (null, response);

    }
}