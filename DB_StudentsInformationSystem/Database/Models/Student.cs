using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_StudentsInformationSystem.Database.Models
{
	public class Student
	{
        [Key]                                               // Primary Key Attribute
        public int StudentId { get; set; }                  // Primary Key Property 'Navigational property'
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string? StudentEmail { get; set; }
        public List<Lecture> Lectures { get; set; }         // Composition to Lecture table 'Has many lectures'
        public Faculty Faculty { get; set; }                // Composition to Faculty table 'Has one faculty'
    }
}
