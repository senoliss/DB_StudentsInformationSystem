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
        public FacultyContext() : base()
        {
        }
        public FacultyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Faculty> Faculty { get; set; }
		public DbSet<Lecture> Lecture { get; set; }
		public DbSet<Student> Student { get; set; }
        public DbSet<FacultyStudent> FacultyStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); galima istrinti

            // universali sintaxe norint uztikrinti sujungima tarp lenteliu
            // cia mes konfiguruojame sarysi su many to many

            modelBuilder.Entity<FacultyStudent>()
                .HasKey(f => new { f.FacultyId, f.StudentId });        // du pirminiai raktai nurodomi skirti sujungti sarysi daug su daug tarp Lecture ir Faculty klasiu / lejnteliu

            modelBuilder.Entity<FacultyStudent>()
                .HasOne(fc => fc.Faculty)
                .WithMany(f => f.FacultyStudents)
                .HasForeignKey(fc => fc.FacultyId);        // Sarysis su Faculty lentele

            modelBuilder.Entity<FacultyStudent>()
                .HasOne(lc => lc.Student)
                .WithMany(l => l.FacultyStudents)
                .HasForeignKey(lc => lc.StudentId);        // sarysis su Lecture lentele

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=DB_SIS;Trusted_Connection=True;");
        }
    }
}
