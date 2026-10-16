using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;

namespace WebApplication1.Services
{
    public interface IUserServices 
    {
        Task<(string? error, UserResponseDto? result)> CreateUserAsync(CreateUserDto request);
        Task<UserResponseDto> GetUserByUserameAsync(string  Username);
        Task<UserResponseDto> GetUserByIdAsync(int id);
        Task<(string Error, LoginUserResponseDto)> LoginUserAsync(LoginUserDto dto);
        Task<(string? error, List<UserResponseDto>? response)> GetAllAsync();
    }
}
