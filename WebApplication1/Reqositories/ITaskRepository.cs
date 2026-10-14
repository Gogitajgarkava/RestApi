using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface ITaskRepository
{
    Task<List<Tasks>> GetAllAsync(string? status = null);
    Task<Tasks?> GetByIdAsync(int id);
    Task<Tasks> CreateAsync(Tasks task);
    Task<Tasks> UpdateTask(Tasks task);
    Task<Tasks?> DeleteTask(int id); 
}