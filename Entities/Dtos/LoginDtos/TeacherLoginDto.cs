using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities.Dtos.LoginDtos
{
	[XmlRoot(ElementName = "TeacherLoginDto")]
	public class TeacherLoginDto : IDto
	{
		[XmlElement(ElementName = "Email")]
		public string Email { get; set; }
		[XmlElement(ElementName = "Password")]
		public string Password { get; set; }
	}
}
