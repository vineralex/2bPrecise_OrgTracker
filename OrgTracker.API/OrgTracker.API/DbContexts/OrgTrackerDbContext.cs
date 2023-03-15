using Microsoft.EntityFrameworkCore;
using OrgTracker.API.Entities;
using Task = OrgTracker.API.Entities.Task;

namespace OrgTracker.API.DbContexts
{
	/// <summary>
	/// Represents the database context for the OrgTracker application.
	/// This class provides access to the underlying database and DbSet properties for querying and modifying data.
	/// </summary>
	public class OrgTrackerDbContext : DbContext
	{
        public OrgTrackerDbContext(DbContextOptions<OrgTrackerDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Task> Tasks { get; set; }
    }
}
