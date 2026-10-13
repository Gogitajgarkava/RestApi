using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Models;
using WebApplication1.Reqositories;

namespace WebApplication1.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepository _repository;

        public TaskServices(ITaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto dto)
        {
            var task = new Tasks
            {
                Title = dto.Title,
                Description = dto.Description,
                Assignee = dto.Assignee,
                Status = dto.Status,
                DueDate = dto.DueDate,
                CreatedAt = DateTime.Now,
            };

            var createdTask = await _repository.CreateAsync(task);

            return new TaskResponseDto
            {
                Title = createdTask.Title,
                Description = createdTask.Description,
                Assignee = createdTask.Assignee,
                Status = createdTask.Status,
                DueDate = createdTask.DueDate
            };
        }

        public async Task DeleteTask(int id)
        {
            await _repository.DeleteTask(id);
        }

        public async Task<List<TaskResponseDto>> GetAllTaskAsync()
        {
            var tasks = await _repository.GetAllAsync();

            return tasks.Select(t => new TaskResponseDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Assignee = t.Assignee,
                Status = t.Status,
                DueDate = t.DueDate,
                CreatedAt = t.CreatedAt,   
            }).ToList();
        }

        public async Task<TaskResponseDto> GetTaskById(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return null;
            return new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Assignee = task.Assignee,
                Status = task.Status,
                DueDate = task.DueDate,
                CreatedAt = task.CreatedAt,
            };
        }

        public async Task<TaskResponseDto> UpdateById(int id, UpdateTaskDto dto)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return null;

            task.DueDate = dto.DueDate;
            task.Status = dto.Status;
            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Assignee = dto.Assignee;
            task.UpdatedAt = dto.UpdatedAt;

            var updateTask = await _repository.UpdateTask(task);

            return  new TaskResponseDto
            {
                Title = task.Title,
                Description = dto.Description,
                Assignee = dto.Assignee,
                Status = dto.Status,
                DueDate = dto.DueDate,
                UpdateAt = dto.UpdatedAt,
            };

        }
    }
    
}