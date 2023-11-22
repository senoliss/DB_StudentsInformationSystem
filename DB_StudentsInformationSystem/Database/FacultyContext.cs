using DB_StudentsInformationSystem.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_StudentsInformationSystem.Database
{
	public class FacultyContext : DbContext
	{
		public FacultyContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<Faculty> Faculty { get; set; }
    }
}
