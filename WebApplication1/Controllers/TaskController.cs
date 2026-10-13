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


        [HttpPost("Create")]
        public async Task<IActionResult> CreateTask(CreateTaskDto dto)
        {
            var createdTask = await _services.CreateTaskAsync(dto);
            return Ok(createdTask);
        }


        [HttpGet("task")]
        public async Task<IActionResult> GetAllTask()
        {
            var tasks = await _services.GetAllTaskAsync();
            return Ok(tasks);

        }

        [HttpGet("task/{id}")]
        public async Task<IActionResult> GetByIdTaskasync(int id) 
        {
            var task = await _services.GetTaskById(id);
            return Ok(task);
        }

        [HttpPatch("task/{id}")]
        public async Task<IActionResult> ChangeTaskById(int id, UpdateTaskDto dto) 
        {
            var task = await _services.UpdateById( id, dto);
            return Ok(task);
        }

        [HttpDelete("task/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _services.DeleteTask(id); 

            return Ok(id);
        }
    }
}
