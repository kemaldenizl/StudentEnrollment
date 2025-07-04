﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
	public class StudentManager : IStudentService
	{
		private IStudentDal _studentDal;

		public StudentManager(IStudentDal studentDal)
		{
			_studentDal = studentDal;
		}

		public List<OperationClaim> GetClaims(Student student)
		{
			return _studentDal.GetClaims(student);
		}

		public void Add(Student student)
		{
			_studentDal.Add(student);
		}

		public Student GetByMail(string email)
		{
			return _studentDal.Get(s => s.Email == email);
		}
		public List<Student> GetAll()
		{
			var result = _studentDal.GetAll();
			foreach (var student in result)
			{
				student.PasswordHash = null;
				student.PasswordSalt = null;
			}
			return result;
		}

		public Student Get(int id)
		{
			var result = _studentDal.Get(s => s.Id == id);
			result.PasswordHash = null;
			result.PasswordSalt = null;
			return result;
		}

		public Student Delete(int id)
		{
			var student = _studentDal.Get(s => s.Id == id);
			var result = _studentDal.Delete(student);
			result.PasswordHash = null;
			result.PasswordSalt = null;
			return result;
		}

		public bool IsEmailExists(string email)
		{
			return _studentDal.IsEmailExists(email);
		}
	}
}