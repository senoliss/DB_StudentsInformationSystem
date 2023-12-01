using System.ComponentModel.DataAnnotations;

namespace DB_StudentsInformationSystem.Database.Models
{
	public class Lecture
    {
        [Key]                                               // Primary Key Attribute
        public int LectureId { get; set; }                  // Primary Key Property 'Navigational' property
        public string LectureName { get; set; }
        public DateTime LectureTimeStart { get; set; }
        public DateTime LectureTimeEnd { get; set; }
        public List<FacultyLecture> FacultyLectures { get; set; }   // Navigational prop to Faculty many to many joint table
        public List<StudentLecture> StudentLectures { get; set; }   // Navigational prop to Student many to many joint table

    }
}
