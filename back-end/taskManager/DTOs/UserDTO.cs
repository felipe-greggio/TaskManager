using task_manager.Domain;

namespace task_manager.DTOs
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public ICollection<TaskDTO>? Tasks { get; set; }
    }
}
