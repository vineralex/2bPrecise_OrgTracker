using Microsoft.AspNetCore.Mvc;
using OrgTracker.API.DTOs;
using OrgTracker.API.Entities;
using OrgTracker.API.Services;

namespace OrgTracker.API.Controllers
{
	/// <summary>
	/// Controller class for handling report-related API endpoints.
	/// </summary>
	public class ReportController : BaseController
	{
		IReportService _reportService;

		// ctor
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

		/// <summary>
		/// Retrieves all reports submitted by subordinates of a specific manager.
		/// </summary>
		/// <param name="managerId">The ID of the manager to retrieve reports for.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ReportDto"/> objects representing reports submitted by subordinates of the specified manager.</returns>
		[HttpGet("GetReportsFromSubordinaries/{managerId}")]
		public ActionResult<IEnumerable<ReportDto>> GetReportsFromSubordinaries(int managerId)
		{
			var reports = _reportService.GetReportsFromSubordinaries(managerId)
				.Select(p => new ReportDto
				{
					Id = p.Id,
					Text = p.Text,
					Date = p.Date
				})
				.ToList();

			if (reports == null)
			{
				return NotFound();
			}

			return Ok(reports);
		}

		/// <summary>
		/// Creates a new report and assigns it to an employee.
		/// </summary>
		/// <param name="reportDto">The report DTO object containing the report details.</param>
		/// <param name="employeeId">The ID of the reporting employee.</param>
		/// <param name="managerId">The ID of the supervising manager.</param>
		/// <returns>An <see cref="ActionResult{T}"/> of <see cref="ReportDto"/> representing the newly created report.</returns>
		[HttpPost("{employeeId}/{managerId}")]
		public ActionResult<ReportDto> Create([FromBody] ReportDto reportDto, int employeeId, int managerId)
		{
			// Validate input
			if (reportDto == null)
			{
				return BadRequest("Report DTO cannot be null.");
			}

			if (managerId <= 0)
			{
				return BadRequest("Manager ID must be greater than zero.");
			}

			if (employeeId <= 0)
			{
				return BadRequest("Employee ID must be greater than zero.");
			}

			// Create new report entity
			var report = new Report
			{				
				Text = reportDto.Text,
				Date = DateTime.Now,
				ReportingEmployeeId = employeeId,
				SupervisingManagerId = managerId
			};

			try
			{
				// Save report to database
				report = _reportService.Create(report);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error creating report: {ex.Message}");
			}

			// Create DTO to return to client
			var createdReportDto = new ReportDto
			{
				Id = report.Id,
				Text = report.Text,
				Date = report.Date				
			};

			// Return the created report DTO with a 201 Created status code
			return CreatedAtAction(nameof(Create), createdReportDto);
		}
	}
}
