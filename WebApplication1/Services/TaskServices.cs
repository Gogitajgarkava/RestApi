using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Models;
using WebApplication1.Repositories;

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
                CreatedAt = DateTime.UtcNow
            };

            var createdTask = await _repository.CreateAsync(task);

            return MapToResponseDto(createdTask);
        }

        public async Task<List<TaskResponseDto>> GetAllTaskAsync(string? status = null)
        {
            var tasks = await _repository.GetAllAsync(status);

            return tasks.Select(MapToResponseDto).ToList();
        }

        public async Task<TaskResponseDto?> GetTaskById(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return null;

            return MapToResponseDto(task);
        }

        public async Task<TaskResponseDto?> UpdateById(int id, UpdateTaskDto dto)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return null;

            if (!string.IsNullOrWhiteSpace(dto.Title))
                task.Title = dto.Title;

            if (dto.Description != null)
                task.Description = dto.Description;

            if (!string.IsNullOrWhiteSpace(dto.Assignee))
                task.Assignee = dto.Assignee;

            if (dto.Status.HasValue)
                task.Status = dto.Status.Value;

            if (dto.DueDate.HasValue)
                task.DueDate = dto.DueDate;

            task.UpdatedAt = DateTime.UtcNow;

            var updatedTask = await _repository.UpdateTask(task);

            return MapToResponseDto(updatedTask);
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return false;

            await _repository.DeleteTask(id);
            return true;
        }

        private static TaskResponseDto MapToResponseDto(Tasks task)
        {
            return new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Assignee = task.Assignee,
                Status = task.Status,
                DueDate = task.DueDate,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            };
        }
    }
}