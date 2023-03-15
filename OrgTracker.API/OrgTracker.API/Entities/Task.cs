using System.ComponentModel.DataAnnotations.Schema;

namespace OrgTracker.API.Entities
{
	/// <summary>
	/// Represents a task assigned to an employee.
	/// </summary>
	[Table("Tasks")]
	public class Task : BaseEntity
	{
		/// <summary>
		/// Gets or sets the text of the task.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets the date on which the task was assigned.
		/// </summary>
		public DateTime AssignedDate { get; set; }

		/// <summary>
		/// Gets or sets the due date of the task.
		/// </summary>
		public DateTime DueDate { get; set; }

		#region Nav Properties

		[ForeignKey(nameof(AssignedTo))]
		public int AssignedToId { get; set; }
		public virtual Employee AssignedTo { get; set; }

		[ForeignKey(nameof(SupervisingManager))]
		public int SupervisingManagerId { get; set; }

		public virtual Employee SupervisingManager { get; set; }

        #endregion
    }
}
