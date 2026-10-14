using WebApplication1.CORE;

namespace WebApplication1.Models
{
    public class Tasks : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public string? Assignee { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}