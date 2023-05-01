using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using task_manager.Domain.Enums;

namespace task_manager.Domain;

public class Project
{
    public Project()
    {
        UserProjects = new Collection<UserProject>();
        Tasks = new Collection<Task>();
    }

    public Guid ProjectId { get; set; }

    [Required]
    [StringLength (300)]
    public string? Name { get; set; }
    public EnumProjectStatus? Status{ get; set; }
    public  DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ICollection<UserProject>? UserProjects { get; set; }
    public ICollection<Task>? Tasks { get; set; }
}
