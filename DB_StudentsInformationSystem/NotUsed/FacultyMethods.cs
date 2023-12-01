//using DB_StudentsInformationSystem.Database;
//using DB_StudentsInformationSystem.Database.Models;
//using Microsoft.EntityFrameworkCore;

//namespace DB_StudentsInformationSystem.NotUsed
//{
//    public class FacultyMethods
//    {
//        public FacultyContext dbContext { get; set; }
//        public FacultyMethods(FacultyContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        public bool ConfirmCreatingFaculty(Faculty faculty)
//        {
//            Console.WriteLine("Faculty will be created with such info: ");
//            Console.WriteLine($"Faculty Name: {faculty.FacultyName}");
//            Console.WriteLine($"Faculty Code: {faculty.FacultyCode}");
//            Console.Write("Do you wish to continue? YES-[y]");

//            string choice = Console.ReadLine();

//            return choice == "y" ? true : false;
//        }
//        public void CreateFaculty()
//        {
//            Faculty faculty = GetFacultyInput();
//            if (IsFacultyInputValidated(faculty))                             // returns bool if faculty is valid
//            {
//                if (ConfirmCreatingFaculty(faculty))                          // returns bool on user choice of confirming correct info
//                {
//                    InsertFacultyInputToDB(faculty);                          // inserts faculty to DB
//                }
//            }
//        }
//        public Faculty GetFacultyInput()
//        {
//            //Here we'll get info required to create Departament
//            Faculty faculty = new Faculty();

//            Console.WriteLine("Enter the name of the Faculty");
//            string facName = Console.ReadLine();
//            Console.WriteLine("Enter the code of the Faculty");
//            string facCode = Console.ReadLine();

//            faculty.FacultyName = facName;
//            faculty.FacultyCode = facCode;

//            return faculty;
//        }

//        public void UpdateFaculty(int facultyChosen, int whatToUpdate)
//        {
//            List<Faculty> faculties = GetFaculties();
//            Faculty facultyToUpdate = faculties[facultyChosen];
//        }
//        public bool IsFacultyInputValidated(Faculty faculty)
//        {
//            //Here we'll Validate info that we got from input to create Departament

//            if (!(ValidateFacultyInput(faculty) == 1))                                                         // all is ok
//            {

//                return false;
//            }
//            return true;
//        }
//        public int ValidateFacultyInput(Faculty faculty)
//        {
//            //Here we'll Validate info that we got from input to create Departament
//            // returns:
//            // 0 - everything is wrong
//            // 1 - everything is validated
//            // 2 - only Name is validated

//            if (faculty.FacultyName.Length >= 3
//                && faculty.FacultyName.Length <= 100)
//            {
//                if (faculty.FacultyCode.Length == 6
//                    && faculty.FacultyCode.Any(char.IsLetter)
//                    && faculty.FacultyCode.Any(char.IsDigit))
//                {
//                    return 1;
//                }
//                // blalala
//                return 2;
//            }
//            return 0;
//        }

//        public void InsertFacultyInputToDB(Faculty faculty)
//        {
//            //Here we'll insert the validated Departament info to DB
//            var dbContext = new FacultyContext();
//            dbContext.Faculties.Add(faculty);
//            dbContext.SaveChanges();
//        }

//        // Gets all the lectures from Lecture DB Table
//        public List<Lecture> GetLectures()
//        {
//            var dbContext = new FacultyContext();
//            List<Lecture> lectures;
//            return lectures = dbContext.Lectures.ToList();
//        }

//        public List<Lecture> GetLecturesByFaculty(int facultyId)
//        {
//            var dbContext = new FacultyContext();
//            List<Lecture> lectures;
//            //return lectures = dbContext.Lecture.Where(s => s.LectureId == (dbContext.FacultyLectures.Select(l => l.FacultyId == 2)).ToList();
//            return lectures = dbContext.FacultyLectures.Where(fl => fl.FacultyId == facultyId).Select(fl => fl.Lecture).ToList();
//        }

//        // Gets all the students from Student DB Table
//        public List<Student> GetStudents()
//        {
//            var dbContext = new FacultyContext();
//            List<Student> students;
//            return students = dbContext.Students.Include(s => s.Faculty).ToList();

//        }
//        public List<Student> GetStudentsByFaculty(int facultyId)
//        {
//            var dbContext = new FacultyContext();
//            List<Student> students;
//            //return lectures = dbContext.Lecture.Where(s => s.LectureId == (dbContext.FacultyLectures.Select(l => l.FacultyId == 2)).ToList();
//            return students = dbContext.Students.Where(fl => fl.Faculty.FacultyId == facultyId).Include(s => s.Faculty).ToList();//.Select(fl => fl.Lecture).ToList();
//        }

//        public List<Faculty> GetFaculties()
//        {
//            var dbContext = new FacultyContext();
//            List<Faculty> faculties;
//            return faculties = dbContext.Faculties.ToList();
//        }

//        // Prints either lectures or students by choice to the console
//        public void Printer(string choice)
//        {
//            int i = 1;
//            if (!string.IsNullOrEmpty(choice))
//            {
//                if (choice == "5")
//                {
//                    List<Faculty> faculties = GetFaculties();
//                    PrintFaculties(faculties);
//                    Console.Write("Enter the number of the faculty: ");
//                    if (!(int.TryParse(Console.ReadLine(), out int facultyId) && facultyId >= 1 && facultyId <= faculties.Count))
//                    {
//                        do
//                        {
//                            Console.WriteLine("Enter the number of the faculty: ");
//                        } while (int.TryParse(Console.ReadLine(), out facultyId) && facultyId >= 1 && facultyId <= faculties.Count);
//                    }

//                    List<Student> students = GetStudentsByFaculty(facultyId);

//                    if (students.Count > 0)
//                    {

//                        foreach (Student student in students)
//                        {
//                            if (student.Faculty.FacultyId != null)
//                            {
//                                Console.WriteLine($"{i}. Student: {student.StudentName} {student.StudentSurname} - {student.StudentNumber} - Faculty: {student.Faculty.FacultyId}");
//                            }
//                            else
//                            {

//                                Console.WriteLine($"{i}. Student: {student.StudentName} {student.StudentSurname} - {student.StudentNumber}");
//                            }
//                            i++;
//                        }
//                    }
//                    else Console.WriteLine("There's no students currentlt in this faculty!");
//                }
//                else if (choice == "6")
//                {
//                    List<Faculty> faculties = GetFaculties();
//                    PrintFaculties(faculties);
//                    Console.Write("Enter the number of the faculty: ");
//                    if (!(int.TryParse(Console.ReadLine(), out int facultyId) && facultyId >= 1 && facultyId <= faculties.Count))
//                    {
//                        do
//                        {
//                            Console.WriteLine("Enter the number of the faculty: ");
//                        } while (int.TryParse(Console.ReadLine(), out facultyId) && facultyId >= 1 && facultyId <= faculties.Count);
//                    }

//                    List<Lecture> lectures = GetLecturesByFaculty(facultyId);

//                    if (lectures.Count > 0)
//                    {
//                        foreach (Lecture lecture in lectures)
//                        {
//                            Console.WriteLine($"{i}. Lecture: {lecture.LectureName} - starts: {lecture.LectureTimeStart} / ends: {lecture.LectureTimeEnd} | Faculty: {faculties.FirstOrDefault(f => f.FacultyId == facultyId).FacultyName}");
//                            i++;
//                        }
//                    }
//                    else Console.WriteLine("There's no lectures currently in this faculty!");
//                }
//                else if (choice == "7")
//                {
//                    List<Student> students = GetStudents();
//                    PrintStudents(students);
//                    Console.Write("Enter the number of the student: ");
//                    if (!(int.TryParse(Console.ReadLine(), out int studentId) && studentId >= 1 && studentId <= students.Count))
//                    {
//                        do
//                        {
//                            Console.WriteLine("Enter the number of the faculty: ");
//                        } while (int.TryParse(Console.ReadLine(), out studentId) && studentId >= 1 && studentId <= students.Count);
//                    }

//                    Student selectedStudent = students[studentId - 1];

//                    try
//                    {
//                        List<Lecture> lectures = GetLecturesByFaculty(selectedStudent.Faculty.FacultyId);
//                        if (lectures.Count > 0)
//                        {
//                            foreach (Lecture lecture in lectures)
//                            {
//                                Console.WriteLine($"{i}. Lecture: {lecture.LectureName} - starts: {lecture.LectureTimeStart} / ends: {lecture.LectureTimeEnd} | Faculty: {selectedStudent.Faculty.FacultyName}");
//                                i++;
//                            }
//                        }
//                        else Console.WriteLine($"Although student is appointed to '{selectedStudent.Faculty.FacultyName}' faculty... \nThere's no lectures currently in this faculty!");
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine($"Although student is appointed to {selectedStudent.Faculty.FacultyName} faculty... \nThere's no lectures currently in this faculty!");
//                    }
//                }
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

//        public void PrintLectures(List<Lecture> lectures)
//        {
//            int i = 1;
//            foreach (var lecture in lectures)
//            {
//                Console.WriteLine($"{i}. Lecture: {lecture.LectureName}");
//                i++;
//            }
//        }

//        public void PrintStudents(List<Student> students)
//        {
//            int i = 1;
//            foreach (var student in students)
//            {
//                Console.WriteLine($"{i}. Student: {student.StudentName} {student.StudentName}");
//                i++;
//            }
//        }
//    }
//}
