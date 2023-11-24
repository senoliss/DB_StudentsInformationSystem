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
        public DbSet<FacultyLecture> FacultyLectures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); galima istrinti

            // universali sintaxe norint uztikrinti sujungima tarp lenteliu
            // cia mes konfiguruojame sarysi su many to many

            modelBuilder.Entity<FacultyLecture>()
                .HasKey(f => new { f.FacultyId, f.LectureId });        // du pirminiai raktai nurodomi skirti sujungti sarysi daug su daug tarp Lecture ir Faculty klasiu / lejnteliu

            modelBuilder.Entity<FacultyLecture>()
                .HasOne(fc => fc.Faculty)
                .WithMany(f => f.FacultyLectures)
                .HasForeignKey(fc => fc.FacultyId);        // Sarysis su Faculty lentele

            modelBuilder.Entity<FacultyLecture>()
                .HasOne(lc => lc.Lecture)
                .WithMany(l => l.FacultyLectures)
                .HasForeignKey(lc => lc.LectureId);        // sarysis su Lecture lentele

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=DB_SIS;Trusted_Connection=True;");
        }
    }
}
