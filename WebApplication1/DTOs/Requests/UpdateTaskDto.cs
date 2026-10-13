using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Requests
{
    public class UpdateTaskDto
    {
        [Required(ErrorMessage = "Fill the Title")]
        [MaxLength(200, ErrorMessage = "No More 200 charapter")]
        public string Title { get; set; }
        public string Description { get; set; }
        public Models.TaskStatus Status { get; set; } = Models.TaskStatus.Preding;

        [Required(ErrorMessage = "Specifying the ass is mandatory")]
        public string? Assignee { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
