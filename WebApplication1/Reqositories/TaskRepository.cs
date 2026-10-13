using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Reqositories;

public class TaskRepository : ITaskRepository
{
    private readonly Baza _context;
    public TaskRepository(Baza context)
    {
        _context = context;
    }

    public async Task<Tasks> CreateAsync(Tasks task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Tasks> DeleteTask(int id)
    {
        var taskRemove = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (taskRemove == null)
        {
            return null; 
        }
        _context.Tasks.Remove(taskRemove);
        await _context.SaveChangesAsync();

        return taskRemove;


    }

    public async Task<List<Tasks>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Tasks?> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<Tasks> UpdateTask(Tasks task)
    {
         _context.Tasks.Update(task);
         _context.SaveChanges();
        return task;
    }
}