﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IAdminService
	{
		List<OperationClaim> GetClaims(Admin admin);
		void Add(Admin admin);
		Admin GetByMail(string email);
		List<Admin> GetAll();
		Admin Get(int id);
		Admin Delete(int id);
		bool IsEmailExists(string email);
	}
}
