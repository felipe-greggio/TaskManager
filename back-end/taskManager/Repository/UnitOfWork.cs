using task_manager.Context;
using task_manager.Repository.Project;
using task_manager.Repository.Task;
using task_manager.Repository.User;

namespace task_manager.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserRepository userRepository;
        private ProjectRepository projectRepository;
        private TaskRepository taskRepository;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return userRepository = userRepository ?? new UserRepository(_context);
            }
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                return projectRepository = projectRepository ?? new ProjectRepository(_context);
            }
        }

        public ITaskRepository TasksRepository
        {
            get
            {
                return taskRepository = taskRepository ?? new TaskRepository(_context);
            }
        }


        public async System.Threading.Tasks.Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
