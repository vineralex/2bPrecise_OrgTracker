namespace OrgTracker.API.DTOs
{
	/// <summary>
	/// Data transfer object for an employee entity.
	/// </summary>
	public class EmployeeDto
	{
		/// <summary>
		/// The unique identifier of the employee.
		/// </summary>
		public int Id { get; set; }
		
		/// <summary>
		/// The first name of the employee.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// The last name of the employee.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// The position of the employee.
		/// </summary>
		public string Position { get; set; }

		/// <summary>
		/// The manager of the employee.
		/// </summary>
		public EmployeeDto Manager { get; set; }
    }
}
