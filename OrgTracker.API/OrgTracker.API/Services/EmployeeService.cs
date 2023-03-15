using Microsoft.EntityFrameworkCore;
using OrgTracker.API.DbContexts;
using OrgTracker.API.Entities;

namespace OrgTracker.API.Services
{
	/// <summary>
	/// Defines the interface for EmployeeService.
	/// </summary>
	public interface IEmployeeService
	{
		/// <summary>
		/// Returns a queryable collection of all employees.
		/// </summary>
		/// <returns>The collection of employees.</returns>
		IQueryable<Employee> GetAll();

		/// <summary>
		/// Returns the employee with the specified ID, including his manager.
		/// </summary>
		/// <param name="id">The ID of the employee.</param>
		/// <returns>The employee with the specified ID, including his manager.</returns>
		Employee GetById(int id);

		/// <summary>
		/// Returns a queryable collection of employees who subordinates to the manager with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the manager.</param>
		/// <returns>The collection of subordinate employees.</returns>
		IQueryable<Employee> GetSubordinaries(int id);
	}

	/// <summary>
	/// Represents an instance of the <see cref="EmployeeService"/> class.
	/// </summary>
	public class EmployeeService : BaseService, IEmployeeService
	{
		// ctor
		public EmployeeService(OrgTrackerDbContext context) : base(context) { }

		/// <inheritdoc/>
		public IQueryable<Employee> GetAll()
		{
			return _context.Employees;
		}

		/// <inheritdoc/>
		public Employee GetById(int id)
		{
			return _context.Employees
				.Include(p=> p.Manager)
				.FirstOrDefault(p => p.Id == id);
		}

		/// <inheritdoc/>
		public IQueryable<Employee> GetSubordinaries(int id)
		{
			return _context.Employees
				.Where(p => p.ManagerId == id);
		}
	}
}
