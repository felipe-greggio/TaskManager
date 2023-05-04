using task_manager.Domain;

namespace task_manager.Repository.Project
{
    public interface IProjectRepository : IRepository<Domain.Project>
    {

        IEnumerable<Domain.Project> GetProjectsUsers(string projectId);
    }
}
