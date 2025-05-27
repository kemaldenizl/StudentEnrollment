using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities.Concrete
{
	public class StudentOperationClaim : IEntity
	{
		[XmlElement(ElementName = "id")]
		public int Id { get; set; }
		[XmlElement(ElementName = "studentId")]
		public int StudentId { get; set; }
		[XmlElement(ElementName = "operationClaimId")]
		public int OperationClaimId { get; set; }
	}
}
