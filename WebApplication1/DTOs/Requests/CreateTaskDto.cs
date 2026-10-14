using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Requests
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public Models.TaskStatus Status { get; set; } = Models.TaskStatus.Pending;

        [Required(ErrorMessage = "Assignee is required")]
        public string Assignee { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }
    }
}