using WebApplication1.Models;

namespace WebApplication1.Reqositories;

public interface ITaskRepository
{
    Task<Tasks> CreateAsync(Tasks task);
    Task<List<Tasks>> GetAllAsync();
    Task<Tasks?> GetByIdAsync(int id);
    Task<Tasks> UpdateTask(Tasks task);
    Task<Tasks> DeleteTask(int id);
}