using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _services;

        public TaskController(ITaskServices services)
        {
            _services = services;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllTasks([FromQuery] string? status)
        {
            var tasks = await _services.GetAllTaskAsync(status);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _services.GetTaskById(id);
            if (task == null)
            {
                return NotFound(new { message = $"Task with ID {id} was not found." });
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
        {
            var createdTask = await _services.CreateTaskAsync(dto);

            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto dto)
        {
            var updatedTask = await _services.UpdateById(id, dto);
            if (updatedTask == null)
            {
                return NotFound(new { message = $"Task with ID {id} was not found." });
            }

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _services.DeleteTask(id);
            if (!success)
            {
                return NotFound(new { message = $"Task with ID {id} was not found." });
            }

            return NoContent(); 
        }
    }
}