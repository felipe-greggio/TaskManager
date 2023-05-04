using System.Linq.Expressions;
using task_manager.Context;
using task_manager.Domain;

namespace task_manager.Repository.User
{
    public class UserRepository : Repository<Domain.User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Domain.User> GetUsersByRole()
        {
            return Get().OrderBy(u => u.Role).ToList();
        }

    }
}
