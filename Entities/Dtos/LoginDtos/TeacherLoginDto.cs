using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.LoginDtos
{
	public class TeacherLoginDto : IDto
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
