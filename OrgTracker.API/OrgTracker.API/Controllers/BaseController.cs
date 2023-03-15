using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrgTracker.API.Controllers
{
	/// <summary>
	/// Base controller for the API controllers to inherit from.
	/// </summary>
	[ApiController]
	[Produces("application/json")]
	[Route("[controller]")]
	public class BaseController : ControllerBase
	{
	}
}
