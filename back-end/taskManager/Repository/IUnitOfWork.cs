using task_manager.Repository.Project;
using task_manager.Repository.User;

namespace task_manager.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProjectRepository ProjectRepository { get; }

        void Commit();

        void Dispose();

    }
}
