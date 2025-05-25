using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		private ICourseService _courseService;
		public CoursesController(ICourseService courseService)
		{
			_courseService = courseService;
		}
	}
}
