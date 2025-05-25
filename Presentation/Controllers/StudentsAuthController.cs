using Business.Abstract.AuthServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsAuthController : ControllerBase
	{
		private IStudentAuthService _studentAuthService;
		public StudentsAuthController(IStudentAuthService studentAuthService)
		{
			_studentAuthService = studentAuthService;
		}


	}
}
