using System.ComponentModel.DataAnnotations.Schema;

namespace OrgTracker.API.Entities
{
	/// <summary>
	/// Represents a report submitted by an employee to their supervising manager.
	/// </summary>
	[Table("Reports")]
	public class Report : BaseEntity
	{
		/// <summary>
		/// The text content of the report.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// The date the report was submitted.
		/// </summary>
		public DateTime Date { get; set; }

		#region Nav Properties

		[ForeignKey(nameof(ReportingEmployee))]
		public int ReportingEmployeeId { get; set; }
		public virtual Employee ReportingEmployee { get; set; }

		[ForeignKey(nameof(SupervisingManager))]
		public int SupervisingManagerId { get; set; }
		public virtual Employee SupervisingManager { get; set; }

		#endregion
	}
}
