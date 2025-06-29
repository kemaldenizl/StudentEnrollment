﻿using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface ITeacherDal : IEntityRepository<Teacher>
	{
		List<OperationClaim> GetClaims(Teacher teacher);
		bool IsEmailExists(string email);
	}
}
