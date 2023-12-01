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

        public DbSet<Faculty> Faculties { get; set; }
		public DbSet<Lecture> Lectures { get; set; }
		public DbSet<Student> Students { get; set; }
        public DbSet<StudentLecture> StudentLectures { get; set; }
        public DbSet<FacultyLecture> FacultyLectures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // universali sintaxe norint uztikrinti sujungima tarp lenteliu
            
            // cia mes konfiguruojame sarysi many to many sujungdami Faculty ir Lecture lenteles

            modelBuilder.Entity<FacultyLecture>()
                .HasKey(f => new { f.FacultyId, f.LectureId });        // du pirminiai raktai nurodomi skirti sujungti sarysi daug su daug tarp Lecture ir Faculty klasiu / lejnteliu

            modelBuilder.Entity<FacultyLecture>()
                .HasOne(fc => fc.Faculty)
                .WithMany(f => f.FacultyLectures)
                .HasForeignKey(fc => fc.FacultyId).OnDelete(DeleteBehavior.Restrict);        // Sarysis su Faculty lentele

            modelBuilder.Entity<FacultyLecture>()
                .HasOne(lc => lc.Lecture)
                .WithMany(l => l.FacultyLectures)
                .HasForeignKey(lc => lc.LectureId).OnDelete(DeleteBehavior.Restrict);        // sarysis su Lecture lentele
            
            // cia mes konfiguruojame sarysi many to many sujungdami Student ir Lecture lenteles

            modelBuilder.Entity<StudentLecture>()
                .HasKey(f => new { f.StudentId, f.LectureId });        // du pirminiai raktai nurodomi skirti sujungti sarysi daug su daug tarp Lecture ir Faculty klasiu / lejnteliu

            modelBuilder.Entity<StudentLecture>()
                .HasOne(fc => fc.Student)
                .WithMany(f => f.StudentLectures)
                .HasForeignKey(fc => fc.StudentId).OnDelete(DeleteBehavior.Restrict);        // Sarysis su Student lentele

            modelBuilder.Entity<StudentLecture>()
                .HasOne(lc => lc.Lecture)
                .WithMany(l => l.StudentLectures)
                .HasForeignKey(lc => lc.LectureId).OnDelete(DeleteBehavior.Restrict);        // sarysis su Lecture lentele

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=DB_SIS2;Trusted_Connection=True;");
        }
    }
}
