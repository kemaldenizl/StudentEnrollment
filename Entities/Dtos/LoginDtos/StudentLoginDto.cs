using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities.Dtos.LoginDtos
{
	[XmlRoot(ElementName = "StudentLoginDto")]
	public class StudentLoginDto : IDto
	{
		[XmlElement(ElementName = "email")]
		public string Email { get; set; }
		[XmlElement(ElementName = "password")]
		public string Password { get; set; }
	}
}
