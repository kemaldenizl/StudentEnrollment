﻿using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IStudentDal : IEntityRepository<Student>
	{
		List<OperationClaim> GetClaims(Student student);
		bool IsEmailExists(string email);
	}
}
