using Microsoft.EntityFrameworkCore;
using task_manager.Domain;
using Task = task_manager.Domain.Task;

namespace task_manager.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
    }

	public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<UserProject> UserProjects { get; set; }
    public DbSet<Task> Tasks { get; set; }

}
