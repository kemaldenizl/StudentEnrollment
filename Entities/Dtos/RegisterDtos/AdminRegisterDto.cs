using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities.Dtos.RegisterDtos
{
	[XmlRoot(ElementName = "AdminRegisterDto")]
	public class AdminRegisterDto : IDto
	{
		[XmlElement(ElementName = "firstName")]
		public string FirstName { get; set; }
		[XmlElement(ElementName = "lastName")]
		public string LastName { get; set; }
		[XmlElement(ElementName = "email")]
		public string Email { get; set; }
		[XmlElement(ElementName = "password")]
		public string Password { get; set; }
		[XmlElement(ElementName = "position")]
		public string Position { get; set; }
	}
}
