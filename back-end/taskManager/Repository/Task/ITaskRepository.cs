namespace task_manager.Repository.Task
{
    public interface ITaskRepository : IRepository<Domain.Task>
    {

        Task<IEnumerable<Domain.Task>> GetTasksByProject(string projectId);
        Task<IEnumerable<Domain.Task>> GetTasksByUser(string userId);
    }
}
