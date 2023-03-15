namespace OrgTracker.API.DTOs
{
	/// <summary>
	/// Data transfer object for a report entity.
	/// </summary>
	public class ReportDto
	{
		/// <summary>
		/// The unique identifier of the report.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// The text content of the report.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// The date the report was submitted.
		/// </summary>
		public DateTime Date { get; set; }
	}
}
