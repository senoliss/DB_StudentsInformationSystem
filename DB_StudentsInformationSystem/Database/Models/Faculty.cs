using System.ComponentModel.DataAnnotations;

namespace DB_StudentsInformationSystem.Database.Models
{
	public class Faculty
    {
        [Key]                                               // Primary Key Attribute
        public int FacultyId { get; set; }                  // Primary Key Property 'Navigational property'
        public string FacultyName { get; set; }
        public string FacultyCode { get; set; }
        public List<Student> Students { get; set; }         // Composition to Student table 'Has many students'
        public List<FacultyLecture> FacultyLectures { get; set; }


    }
}
