using Microsoft.EntityFrameworkCore;
using task_manager.Context;
using task_manager.Repository.Project;

namespace task_manager.Repository.Task
{

    public class TaskRepository : Repository<Domain.Task>, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Task>> GetTasksByProject(string projectId)
        {
            return await Get().Where(x => x.ProjectId.Equals(projectId)).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Task>> GetTasksByUser(string userId)
        {
            return await Get().Where(x => x.UserId.Equals(userId)).ToListAsync();
        }
    }
}
