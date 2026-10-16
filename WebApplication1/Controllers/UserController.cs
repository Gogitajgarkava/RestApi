using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requests;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;

        public UserController(IUserServices services)
        {
            _services = services;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var (error, response) = await _services.CreateUserAsync(dto);

            if (error != null)
            {
                return BadRequest(new { message = error });
            }

            return CreatedAtAction(
                nameof(GetUserByUsername),
                new { username = response!.Username },
                response
            );
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _services.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = $"User '{id}' was not found. " });
            }

            return Ok(user);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _services.GetUserByUserameAsync(username);
            if (user == null)
            {
                return NotFound(new { message = $"User '{username}' was not found." });
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto dto)
        {
            var (error, loginUser) = await _services.LoginUserAsync(dto);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(new { message = error });
            }
            return Ok(loginUser);
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var (error, response) = await _services.GetAllAsync();

            if (error != null)
            {
                return BadRequest(new { message = error });
            }

            return Ok(response);
        }

    }
}