namespace task_manager.Domain;

public class UserProject
{
    public Guid UserProjectId { get; set; }
    public Guid UserId  { get; set; }
    public User? User { get; set; }
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}
