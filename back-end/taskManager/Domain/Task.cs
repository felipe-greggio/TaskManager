using task_manager.Domain.Enums;

namespace task_manager.Domain;

public class Task
{
    public Guid TaskId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public EnumTaskStatus? Status { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }

}
