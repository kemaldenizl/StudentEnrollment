using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface ITeacherService
	{
		List<OperationClaim> GetClaims(Teacher teacher);
		void Add(Teacher teacher);
		Teacher GetByMail(string email);
		List<Teacher> GetAll();
		Teacher Get(int id);
		void Delete(int id);
	}
}
