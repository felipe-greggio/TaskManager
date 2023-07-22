using task_manager.Domain;

namespace task_manager.DTOs
{
    public class UserProjectDTO
    {
        public Guid UserProjectId { get; set; }
        public UserDTO? User { get; set; }
    }
}
