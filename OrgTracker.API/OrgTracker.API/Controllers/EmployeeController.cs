using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrgTracker.API.DTOs;
using OrgTracker.API.Entities;
using OrgTracker.API.Services;

namespace OrgTracker.API.Controllers
{
	/// <summary>
	/// Controller class for handling employee-related API endpoints.
	/// </summary>
	public class EmployeeController : BaseController
	{
		IEmployeeService _employeeService;

		// ctor
		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		/// <summary>
		/// Retrieves all employees as a collection of EmployeeDto objects.
		/// </summary>
		/// <returns>A collection of EmployeeDto objects representing all employees.</returns>
		[HttpGet(Name = "GetAllEmployees")]
		public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployees()
		{
			var employees = _employeeService.GetAll()
				.Select(p => new EmployeeDto
				{
					Id = p.Id,
					FirstName = p.FirstName,
					LastName = p.LastName,
					Position = p.Position
				})
				.ToList();
			if (employees == null || employees.Count == 0)
			{
				return NotFound();
			}

			return Ok(employees);
		}

		/// <summary>
		/// Retrieves an individual employee by his ID.
		/// </summary>
		/// <param name="id">The ID of the employee to retrieve.</param>
		/// <returns>The requested employee.</returns>
		[HttpGet("{id}")]
		public ActionResult<EmployeeDto> GetEmployee(int id)
		{
			Employee employee = _employeeService.GetById(id);

			if (employee == null)
			{
				return NotFound();
			}

			// TODO: mapping will be appropriate here
			var employeeDto = new EmployeeDto
			{
				Id = employee.Id,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				Position = employee.Position,
			};
			if (employee.Manager != null)
			{
				employeeDto.Manager = new EmployeeDto
				{
					Id = employee.Manager.Id,
					FirstName = employee.Manager.FirstName,
					LastName = employee.Manager.LastName,
					Position = employee.Manager.Position
				};
			}

			return Ok(employeeDto);
		}

		/// <summary>
		/// Retrieves all subordinates of a specified manager as a collection of EmployeeDto objects.
		/// </summary>
		/// <param name="id">The ID of the manager whose subordinates are to be retrieved.</param>
		/// <returns>A collection of EmployeeDto objects representing the subordinates of the specified manager.</returns>
		[HttpGet("GetSubordinaries/{id}", Name = "GetSubordinaries")]
		public ActionResult<IEnumerable<EmployeeDto>> GetSubordinaries(int id)
		{
			try
			{
				var subordinates = _employeeService.GetSubordinaries(id)
					.Select(p => new EmployeeDto
					{
						Id = p.Id,
						FirstName = p.FirstName,
						LastName = p.LastName,
						Position = p.Position
					}).ToList();

				if (subordinates == null)
				{
					return NotFound();
				}

				return Ok(subordinates);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error retrieving subordinates: {ex.Message}");
			}
		}
	}
}
