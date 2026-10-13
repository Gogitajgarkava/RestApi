using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;

namespace WebApplication1.Services
{
    public interface ITaskServices
    {
        Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto dto);
        Task<List<TaskResponseDto>> GetAllTaskAsync();
        Task<TaskResponseDto> GetTaskById(int id);
        Task<TaskResponseDto> UpdateById(int id, UpdateTaskDto dto);
        Task DeleteTask(int id);
    }
}