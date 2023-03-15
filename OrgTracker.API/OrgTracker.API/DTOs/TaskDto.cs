namespace OrgTracker.API.DTOs
{
	/// <summary>
	/// Data transfer object for a task entity.
	/// </summary>
	public class TaskDto
	{
		/// <summary>
		/// The unique identifier of the task.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// The text content of the task.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// The date on which the task was assigned.
		/// </summary>
		public DateTime AssignedDate { get; set; }

		/// <summary>
		/// The due date of the task.
		/// </summary>
		public DateTime DueDate { get; set; }

	}
}
