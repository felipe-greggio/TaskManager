using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Domain.User>> GetUsersByRole()
        {
            return await Get().OrderBy(u => u.Role).ToListAsync();
        }

    }
}
