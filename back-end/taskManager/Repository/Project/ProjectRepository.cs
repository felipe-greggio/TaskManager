using Microsoft.EntityFrameworkCore;
using task_manager.Context;
using task_manager.Domain;

namespace task_manager.Repository.Project
{
    public class ProjectRepository : Repository<Domain.Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Project>> GetProjectsUsers(string projectId)
        {
            return await Get().Include(u => u.UserProjects).ThenInclude(u => u.User).Where(x => x.ProjectId.Equals(projectId)).ToListAsync();
        }
    }
}
