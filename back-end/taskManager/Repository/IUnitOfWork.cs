using task_manager.Repository.Project;
using task_manager.Repository.Task;
using task_manager.Repository.User;

namespace task_manager.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ITaskRepository TasksRepository { get; }
        System.Threading.Tasks.Task Commit();

        void Dispose();

    }
}
