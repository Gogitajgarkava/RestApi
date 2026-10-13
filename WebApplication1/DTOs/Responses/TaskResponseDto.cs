using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Responses
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Models.TaskStatus Status { get; set; }
        public string? Assignee { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
