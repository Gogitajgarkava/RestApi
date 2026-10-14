using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Requests
{
    public class UpdateTaskDto
    {
        [MaxLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public Models.TaskStatus? Status { get; set; }

        public string? Assignee { get; set; }

        public DateTime? DueDate { get; set; }
    }
}