using System.ComponentModel.DataAnnotations;

namespace DB_StudentsInformationSystem.Database.Models
{
	public class Lecture
    {
        [Key]                                               // Primary Key Attribute
        public int LectureId { get; set; }                  // Primary Key Property 'Navigational property'
        public string LectureName { get; set; }
        public DateTime LectureTimeStart { get; set; }
        public DateTime LectureTimeEnd { get; set; }
        //public List<Faculty> Faculties { get; set; }         // Composition to Faculty table 'Has many faculties' ????
        public List<FacultyLecture> FacultyLectures { get; set; }

    }
}
