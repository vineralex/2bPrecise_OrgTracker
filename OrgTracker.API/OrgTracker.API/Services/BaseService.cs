using Microsoft.EntityFrameworkCore;
using OrgTracker.API.DbContexts;

namespace OrgTracker.API.Services
{
	/// <summary>
	/// Base service class providing a DbContext instance to its derived classes.
	/// </summary>
	public class BaseService
	{
		internal OrgTrackerDbContext _context;

		/// <summary>
		/// Initializes a new instance of the BaseService class with the specified DbContext.
		/// </summary>
		/// <param name="context">The DbContext instance to be used.</param>
		public BaseService(OrgTrackerDbContext context)
        {
            _context = context;
        }
    }
}
