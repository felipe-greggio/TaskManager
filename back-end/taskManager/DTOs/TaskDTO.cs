using task_manager.Domain.Enums;
using task_manager.Domain;

namespace task_manager.DTOs
{
    public class TaskDTO
    {

        public Guid TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public EnumTaskStatus? Status { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
