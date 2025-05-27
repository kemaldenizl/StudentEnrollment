using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Core.Entities.Abstract;

namespace Entities.Dtos.RegisterDtos
{
	[XmlRoot(ElementName = "StudentRegisterDto")]
	public class StudentRegisterDto : IDto
	{
		[XmlElement(ElementName = "firstName")]
		public string FirstName { get; set; }
		[XmlElement(ElementName = "lastName")]
		public string LastName { get; set; }
		[XmlElement(ElementName = "email")]
		public string Email { get; set; }
		[XmlElement(ElementName = "password")]
		public string Password { get; set; }
		[XmlElement(ElementName = "enrollmentDate")]
		public DateTime EnrollmentDate { get; set; }
		[XmlElement(ElementName = "classroom")]
		public string Classroom { get; set; }
	}
}
