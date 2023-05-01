using System.Collections.ObjectModel;

namespace task_manager.Domain;

public class User
{
    public User()
    {
        UserProjects = new Collection<UserProject>();
        Tasks = new Collection<Task>();
    }

    public Guid UserId  { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role{ get; set; }
    public DateTime? RegisterDate { get; set; }

    public ICollection<UserProject>? UserProjects { get; set; }
    public ICollection<Task>? Tasks { get; set; }
}
