//using DB_StudentsInformationSystem.Database;
//using DB_StudentsInformationSystem.Database.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Globalization;

//namespace DB_StudentsInformationSystem.NotUsed
//{
//    public class LectureMethods
//    {
//        public FacultyContext dbContext { get; set; }
//        public LectureMethods(FacultyContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }
//        public void CreateLectureAndAssignToFaculty()
//        {
//            // Have to have maybe two methods, one for creating students to list without faculty from opt 4, and another to directly create and assign a faculty to it.
//            Lecture lectureToInput = GetLectureInput();                // returns student object from user input

//            if (ConfirmCreatingLecture(lectureToInput))                             // returns bool if student is valid
//            {
//                InsertLectureInputToDB(lectureToInput);                              // inserts student to DB
//                AssignLectureToFacultyAndUpdateDB(lectureToInput);
//            }

//        }

//        public Lecture GetLectureInput()
//        {
//            //Here we'll get info required to create Lecture and validate the lecture time in the same method
//            Lecture lecture = new Lecture();

//            Console.WriteLine("Enter the name of the Lecture");
//            string lecName = Console.ReadLine();

//            // Get and validate lecture start time
//            DateTime lecStartTime;
//            do
//            {
//                Console.WriteLine($"At what time lecture {lecName} starts? (HH:mm)");
//                string startTimeInput = Console.ReadLine();

//                if (DateTime.TryParseExact(startTimeInput, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out lecStartTime))
//                {
//                    break;
//                }
//                else
//                {
//                    Console.WriteLine("Invalid time format. Please enter the time in HH:mm format.");
//                }
//            } while (true);

//            // Get and validate lecture end time
//            DateTime lecEndTime;
//            do
//            {
//                Console.WriteLine($"At what time lecture {lecName} ends? (HH:mm)");
//                string endTimeInput = Console.ReadLine();

//                if (DateTime.TryParseExact(endTimeInput, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out lecEndTime))
//                {
//                    break;
//                }
//                else
//                {
//                    Console.WriteLine("Invalid time format. Please enter the time in HH:mm format.");
//                }
//            } while (true);

//            lecture.LectureName = lecName;
//            lecture.LectureTimeStart = lecStartTime;
//            lecture.LectureTimeEnd = lecEndTime;

//            return lecture;
//        }

//        public bool ConfirmCreatingLecture(Lecture lecture)
//        {
//            Console.WriteLine("Lecture will be created with such info: ");
//            Console.WriteLine($"Lecture Name: {lecture.LectureName}");
//            Console.WriteLine($"Lecture start time: {lecture.LectureTimeStart}");
//            Console.WriteLine($"Lecture end time: {lecture.LectureTimeEnd}");
//            Console.Write("Do you wish to continue? YES-[y]");

//            string choice = Console.ReadLine();

//            return choice == "y" ? true : false;
//        }

//        public void InsertLectureInputToDB(Lecture lecture)
//        {
//            var dbContext = new FacultyContext();
//            dbContext.Lectures.Add(lecture);
//            dbContext.SaveChanges();
//        }

//        public void AssignLectureToFacultyAndUpdateDB(Lecture lecture)
//        {
//            List<Faculty> faculties = GetFaculties();
//            PrintFaculties(faculties);

//            Console.Write($"Enter the number of the faculty to assign lecture {lecture.LectureName}: ");
//            if (int.TryParse(Console.ReadLine(), out int facultyNumber) && facultyNumber >= 1 && facultyNumber <= faculties.Count)
//            {
//                // Subtract 1 to get the correct index in the list
//                Faculty selectedFaculty = faculties[facultyNumber - 1];

//                // Assign the selected faculty to the student
//                var dbContext = new FacultyContext();
//                if (selectedFaculty != null && lecture != null)
//                {
//                    // EF will automatically manage the FacultyLecture table
//                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
//                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { Faculty = selectedFaculty, Lecture = lecture});
//                    dbContext.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
//                    dbContext.SaveChanges();
//                }

//                Console.WriteLine($"Lecture {lecture.LectureName} assigned to {selectedFaculty.FacultyName} faculty.");
//            }
//            else
//            {
//                Console.WriteLine("Invalid input. Please enter a valid faculty number.");
//            }
//        }

//        public void PrintFaculties(List<Faculty> faculties)
//        {
//            int i = 1;
//            foreach (var faculty in faculties)
//            {
//                Console.WriteLine($"{i}. Faculty: {faculty.FacultyName} - {faculty.FacultyCode}");
//                i++;
//            }
//        }

//        public List<Faculty> GetFaculties()
//        {
//            var dbContext = new FacultyContext();
//            List<Faculty> faculties;
//            return faculties = dbContext.Faculties.Include(s => s.FacultyLectures).ToList();
//        }
//    }
//}
