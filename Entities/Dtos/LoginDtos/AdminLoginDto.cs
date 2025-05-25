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
		[XmlElement(ElementName = "Email")]
		public string Email { get; set; }
		[XmlElement(ElementName = "Password")]
		public string Password { get; set; }
	}
}
