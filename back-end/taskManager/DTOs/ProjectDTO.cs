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
        public ICollection<UserDTO>? Users { get; set; }
    }
}
