using DB_StudentsInformationSystem.Database;
using DB_StudentsInformationSystem.Database.Models;

namespace DB_StudentsInformationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new FacultyContext();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var scienceFaculty = new Faculty { FacultyName = "Sciences" };
            var languageFaculty = new Faculty { FacultyName = "Language" };
            var engineerFaculty = new Faculty { FacultyName = "Engineering" };
            dbContext.Faculty.AddRange(scienceFaculty, languageFaculty, engineerFaculty);

            Lecture lecture1 = new Lecture { LectureName = "Biologija" };
            var lecture2 = new Lecture { LectureName = "Matematika" };
            var lecture3 = new Lecture { LectureName = "Fizika" };
            var lecture4 = new Lecture { LectureName = "Anglu" };
            var lecture5 = new Lecture { LectureName = "Daile" };
            var lecture6 = new Lecture { LectureName = "Rusu" };
            var lecture7 = new Lecture { LectureName = "Lietuviu" };
            var lecture8 = new Lecture { LectureName = "Chemija" };

            dbContext.Lecture.AddRange(lecture1, lecture2, lecture3, lecture4, lecture5, lecture6, lecture7, lecture8);

            List<Lecture> lectures1 = new List<Lecture>();
            lectures1.Add(lecture1);
            lectures1.Add(lecture3);
            lectures1.Add(lecture5);

            List<Lecture> lectures2 = new List<Lecture>();
            lectures2.Add(lecture2);
            lectures2.Add(lecture4);
            lectures2.Add(lecture6);

            List<Lecture> lectures3 = new List<Lecture>();
            lectures3.Add(lecture7);
            lectures3.Add(lecture8);

            var testStudent1 = new Student { StudentName = "Tomas", StudentSurname = "Babajus", Lectures = lectures1, Faculty = scienceFaculty };
            var testStudent2 = new Student { StudentName = "Dinas", StudentSurname = "Karabinas", Lectures = lectures2, Faculty = languageFaculty };
            var testStudent3 = new Student { StudentName = "Lukas", StudentSurname = "Bambukas", Lectures = lectures3, Faculty = engineerFaculty };

            dbContext.Student.AddRange(testStudent1, testStudent2, testStudent3);


            dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = scienceFaculty, Lecture = lecture1 });
            dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = scienceFaculty, Lecture = lecture8 });

            dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = engineerFaculty, Lecture = lecture2 });
            dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = engineerFaculty, Lecture = lecture3 });
            dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = engineerFaculty, Lecture = lecture5 });

            dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = languageFaculty, Lecture = lecture4 });
            dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = languageFaculty, Lecture = lecture6 });
            dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = languageFaculty, Lecture = lecture7 });

            dbContext.SaveChanges();
        }
    }
}
