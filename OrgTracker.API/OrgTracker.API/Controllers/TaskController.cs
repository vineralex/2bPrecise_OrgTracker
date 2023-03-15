using Microsoft.AspNetCore.Mvc;
using OrgTracker.API.DTOs;
using OrgTracker.API.Services;
using Task = OrgTracker.API.Entities.Task;

namespace OrgTracker.API.Controllers
{
	/// <summary>
	/// Controller class for handling task-related API endpoints.
	/// </summary>
	public class TaskController : BaseController
	{
		ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
			_taskService = taskService;
        }

		/// <summary>
		/// Retrieves all tasks assigned to a specific employee.
		/// </summary>
		/// <param name="employeeId">The ID of the employee to retrieve tasks for.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of <see cref="TaskDto"/> objects representing tasks assigned to the specified employee.</returns>
		[HttpGet("GetTasksAssignedToEmployee/{employeeId}")]
		public ActionResult<IEnumerable<TaskDto>> GetTasksAssignedToEmployee(int employeeId)
		{
			var tasks = _taskService.GetTasksAssignedToEmployee(employeeId)
				.Select(p => new TaskDto
				{
					Id = p.Id,
					Text = p.Text,
					AssignedDate = p.AssignedDate,
					DueDate = p.DueDate
				})
				.ToList();
			if (tasks == null)
			{
				return NotFound();
			}

			return Ok(tasks);
		}

		/// <summary>
		/// Creates a new task assigned to a specific employee and supervised by a specific manager.
		/// </summary>
		/// <param name="taskDto">The <see cref="TaskDto"/> object representing the task to create.</param>
		/// <param name="managerId">The ID of the manager supervising the task.</param>
		/// <param name="assignToId">The ID of the employee the task is assigned to.</param>
		/// <returns>The <see cref="TaskDto"/> object representing the created task.</returns>
		[HttpPost("{managerId}/{assignToId}")]
		public ActionResult<TaskDto> Create([FromBody] TaskDto taskDto, int managerId, int assignToId)
		{
			// Validate input
			if (taskDto == null)
			{
				return BadRequest("Task DTO cannot be null.");
			}

			if (managerId <= 0)
			{
				return BadRequest("Manager ID must be greater than zero.");
			}

			if (assignToId <= 0)
			{
				return BadRequest("Assignee ID must be greater than zero.");
			}

			// Create new task entity
			var task = new Task
			{
				AssignedDate = DateTime.UtcNow,
				AssignedToId = assignToId,
				SupervisingManagerId = managerId,
				DueDate = taskDto.DueDate,
				Text = taskDto.Text,
			};

			try
			{
				// Save task to database
				task = _taskService.Create(task);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error creating task: {ex.Message}");
			}

			// Create DTO to return to client
			var createdTaskDto = new TaskDto
			{
				Id = task.Id,
				Text = task.Text,
				AssignedDate = task.AssignedDate,
				DueDate = task.DueDate
			};

			// Return the created task DTO with a 201 Created status code
			return CreatedAtAction(nameof(Create), createdTaskDto);
		}
	}
}
