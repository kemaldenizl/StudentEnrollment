using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IStudentService
	{
		List<OperationClaim> GetClaims(Student student);
		void Add(Student student);
		Student GetByMail(string email);
		List<Student> GetAll();
		Student Get(int id);
		void Delete(int id);
	}
}
