using System.ComponentModel.DataAnnotations;
using task_manager.Domain.Enums;
using task_manager.Domain;

namespace task_manager.DTOs
{
    public class ProjectDTO
    {
        public Guid ProjectId { get; set; }

        public string? Name { get; set; }
        public EnumProjectStatus? Status { get; set; }
        public ICollection<UserProjectDTO>? UserProjects { get; set; }
        public ICollection<TaskDTO>? Tasks { get; set; }
    }
}
