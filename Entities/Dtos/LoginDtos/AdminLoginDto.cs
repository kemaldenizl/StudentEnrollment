using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Core.Entities.Abstract;

namespace Entities.Dtos.LoginDtos
{
	[XmlRoot(ElementName = "AdminLoginDto")]
	public class AdminLoginDto : IDto
	{
		[XmlElement(ElementName = "email")]
		public string Email { get; set; }
		[XmlElement(ElementName = "password")]
		public string Password { get; set; }
	}
}
