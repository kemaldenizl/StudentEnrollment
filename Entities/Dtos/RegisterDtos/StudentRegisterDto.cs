using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Dtos.RegisterDtos
{
	public class StudentRegisterDto : IDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime EnrollmentDate { get; set; }
		public string Classroom { get; set; }
	}
}
