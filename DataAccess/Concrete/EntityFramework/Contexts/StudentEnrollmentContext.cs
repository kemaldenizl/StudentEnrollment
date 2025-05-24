using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
	public class StudentEnrollmentContext:DbContext
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-3C9L670;Database=StudentEnrollment;Trusted_Connection=true;TrustServerCertificate=True");
			//this connection string is temporarily here. After testing api this connection string will go to appsettings.json file.
		}
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<TeacherOperationClaim> TeacherOperationClaims { get; set; }

		public DbSet<Student> Students { get; set; }
		public DbSet<StudentOperationClaim> StudentOperationClaims { get; set; }

		public DbSet<Admin> Admins { get; set; }
		public DbSet<AdminOperationClaim> AdminOperationClaims { get; set; }

		public DbSet<Course> Courses { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }

		public DbSet<OperationClaim> OperationClaims { get; set; }
	}
}
