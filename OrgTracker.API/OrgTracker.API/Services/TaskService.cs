using OrgTracker.API.DbContexts;
using Task = OrgTracker.API.Entities.Task;

namespace OrgTracker.API.Services
{
	/// <summary>
	/// Defines the interface for TaskService.
	/// </summary>
	public interface ITaskService
	{
		/// <summary>
		/// Creates a new task.
		/// </summary>
		/// <param name="task">The task to create.</param>
		/// <returns>The created task.</returns>
		Task Create(Task task);

		/// <summary>
		/// Retrieves all tasks assigned to a specific employee.
		/// </summary>
		/// <param name="assignedToId">The ID of the employee to retrieve tasks for.</param>
		/// <returns>An <see cref="IQueryable{T}"/> of <see cref="Task"/> objects assigned to the specified employee.</returns>
		IQueryable<Task> GetTasksAssignedToEmployee(int assignedToId);
	}

	/// <summary>
	/// Represents an instance of the <see cref="TaskService"/> class.
	/// </summary>
	public class TaskService : BaseService, ITaskService
	{
		// ctor
		public TaskService(OrgTrackerDbContext context) : base(context) { }

		/// <inheritdoc/>
		public Task Create(Task task)
		{
			_context.Tasks.Add(task);
			_context.SaveChanges();
			return task;
		}

		/// <inheritdoc/>
		public IQueryable<Task> GetTasksAssignedToEmployee(int assignedToId) { 
			return _context.Tasks
				.Where(p => p.AssignedToId == assignedToId);
		}
	}
}
