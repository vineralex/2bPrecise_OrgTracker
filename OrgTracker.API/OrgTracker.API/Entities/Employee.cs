using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrgTracker.API.Entities
{
	/// <summary>
	/// Represents an employee in the organization.
	/// </summary>
	[Table("Employees")]
	public class Employee : BaseEntity
	{
		/// <summary>
		/// Gets or sets the first name of the employee.
		/// </summary>
		[MaxLength(20)]
        public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name of the employee.
		/// </summary>
		[MaxLength(20)]
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the position of the employee.
		/// </summary>
		[MaxLength(40)]
		public string Position { get; set; }

		#region Nav Properties

		/// <summary>
		/// Gets or sets the manager of the employee.
		/// </summary>
		[ForeignKey(nameof(Manager))]
        public int? ManagerId { get; set; }
		public virtual Employee Manager { get; set; }

		/// <summary>
		/// Gets or sets the subordinates of the manager.
		/// </summary>
		[InverseProperty(nameof(Manager))]
		public virtual ICollection<Employee> Subordinates { get; set;}

		[InverseProperty(nameof(Report.SupervisingManager))]
		public virtual ICollection<Report> Reports { get; set; }

		[InverseProperty(nameof (Task.AssignedTo))]
		public virtual ICollection<Task> Tasks { get; set; }

		#endregion
	}
}
