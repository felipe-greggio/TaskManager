using task_manager.Domain;

namespace task_manager.Repository.User
{
    public interface IUserRepository : IRepository<Domain.User>
    {

        Task<IEnumerable<Domain.User>> GetUsersByRole();
    }
}
