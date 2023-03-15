using OrgTracker.API.DbContexts;
using OrgTracker.API.Entities;

namespace OrgTracker.API.Services
{
	/// <summary>
	/// Defines the interface for ReportService.
	/// </summary>
	public interface IReportService
	{
		/// <summary>
		/// Creates a new report.
		/// </summary>
		/// <param name="report">The report to create.</param>
		/// <returns>The created report.</returns>
		Report Create(Report report);

		/// <summary>
		/// Retrieves all reports submitted by subordinates of a specific manager.
		/// </summary>
		/// <param name="managerId">The ID of the manager to retrieve reports for.</param>
		/// <returns>An <see cref="IQueryable{T}"/> of <see cref="Report"/> objects submitted by subordinates of the specified manager.</returns>
		IQueryable<Report> GetReportsFromSubordinaries(int managerId);
	}

	/// <summary>
	/// Represents an instance of the <see cref="ReportService"/> class.
	/// </summary>
	public class ReportService : BaseService, IReportService
	{
		public ReportService(OrgTrackerDbContext context) : base(context) { }

		/// <inheritdoc/>
		public Report Create(Report report)
		{
			_context.Reports.Add(report);
			_context.SaveChanges();
			return report;
		}

		/// <inheritdoc/>
		public IQueryable<Report> GetReportsFromSubordinaries(int managerId) 
		{
			return _context.Reports
				.Where(p => p.SupervisingManagerId == managerId);
		}
	}
}
