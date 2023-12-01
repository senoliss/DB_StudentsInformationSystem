//using DB_StudentsInformationSystem.Database;
//using DB_StudentsInformationSystem.Database.Models;
//using System.Text.RegularExpressions;

//namespace DB_StudentsInformationSystem.NotUsed
//{
//    public class StudentMethods
//    {
//        public FacultyContext dbContext { get; set; }
//        public StudentMethods(FacultyContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }
//        public bool CheckIfAnyFacultyExists()
//        {
//            List<Faculty> faculties = GetFaculties();

//            return faculties.Count > 0;
//        }
//        public List<Faculty> GetFaculties()
//        {
//            var dbContext = new FacultyContext();
//            List<Faculty> faculties;
//            return faculties = dbContext.Faculties.ToList();
//        }
//        //public static void DeleteStudent()
//        //{
//        //    var dbContext = new FacultyContext();
//        //    var studentToDelete = dbContext.Student.FirstOrDefault(s => s.Faculty.FacultyCode == "TEST01");
//        //    if (studentToDelete != null)
//        //    {
//        //        dbContext.Student.Remove(studentToDelete);
//        //        dbContext.SaveChanges();
//        //    }
//        //}
//        public void CreateStudentAndAssignFaculty()
//        {
//            // Have to have maybe two methods, one for creating students to list without faculty from opt 4, and another to directly create and assign a faculty to it.
//            Student studentToInput = GetStudentInputUntilValidated();                // returns student object from user input

//            if (IsStudentInputValidated(studentToInput))                             // returns bool if student is valid
//            {
//                AddStudentToFaculty(ref studentToInput);
//                //InsertStudentInputToDB(studentToInput);     // not needed since we add, update and save changes in UpdateStudentFaculty() method
//            }
//        }
//        public void AddStudentToFaculty(ref Student student)
//        {
//            List<Faculty> faculties = GetFaculties();
//            PrintFaculties(faculties);


//            Console.Write($"Enter the number of the faculty to assign student {student.StudentName} {student.StudentSurname} to: ");
//            if (int.TryParse(Console.ReadLine(), out int facultyNumber) && facultyNumber >= 1 && facultyNumber <= faculties.Count)
//            {
//                // Subtract 1 to get the correct index in the list
//                Faculty selectedFaculty = faculties[facultyNumber - 1];

//                // Assign the selected faculty to the student
//                var dbContext = new FacultyContext();
//                if (selectedFaculty != null && student != null)
//                {
//                    // EF will automatically manage the FacultyLecture table
//                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
//                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { Faculty = selectedFaculty, Lecture = lecture});
//                    //dbContext.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
//                    student.Faculty = selectedFaculty;
//                    dbContext.Students.Add(student);
//                    dbContext.SaveChanges();
//                }

//                Console.WriteLine($"Student {student.StudentName} {student.StudentSurname} assigned to {selectedFaculty.FacultyName} faculty.");
//            }
//            else
//            {
//                Console.WriteLine("Invalid input. Please enter a valid faculty number.");
//            }
//        }

//        public void UpdateStudentFaculty(ref Student student)
//        {
//            List<Faculty> faculties = GetFaculties();
//            PrintFaculties(faculties);
//            var dbContext = new FacultyContext();
//            var studentToUpdate = dbContext.Students.Find(student.StudentId);        // Finds the new student object without fetching faculty by existing student object studentId

//            Console.Write($"Enter the number of the faculty to assign student {student.StudentName} {student.StudentSurname} to: ");
//            if (int.TryParse(Console.ReadLine(), out int facultyNumber) && facultyNumber >= 1 && facultyNumber <= faculties.Count)
//            {
//                // Subtract 1 to get the correct index in the list
//                Faculty selectedFaculty = faculties[facultyNumber - 1];

//                // Assign the selected faculty to the student
//                if (selectedFaculty != null && student != null)
//                {
//                    // EF will automatically manage the FacultyLecture table
//                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
//                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { Faculty = selectedFaculty, Lecture = lecture});
//                    //dbContext.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
//                    //dbContext.Student.Add(student);
//                    //student.FacultyId = selectedFaculty.FacultyId;
//                    studentToUpdate.Faculty = selectedFaculty;      // Updates existing student in db with overrwritend faculty data
//                    dbContext.SaveChanges();
//                }

//                Console.WriteLine($"Student {student.StudentName} {student.StudentSurname} assigned to {selectedFaculty.FacultyName} faculty.");
//            }
//            else
//            {
//                Console.WriteLine("Invalid input. Please enter a valid faculty number.");
//            }
//        }

//        public void TransferStudentToAnotherFaculty()
//        {
//            List<Student> students = FacultyMethods.GetStudents();
//            Console.WriteLine("Select student to change faculties: ");
//            FacultyMethods.PrintStudents(students);

//            if (!(int.TryParse(Console.ReadLine(), out int studentId) && studentId >= 1 && studentId <= students.Count))
//            {
//                do
//                {
//                    Console.WriteLine("Enter the number of the faculty: ");
//                } while (int.TryParse(Console.ReadLine(), out studentId) && studentId >= 1 && studentId <= students.Count);
//            }

//            Student selectedStudent = students[studentId - 1];
//            Console.WriteLine($"Selected student: {selectedStudent.StudentName} {selectedStudent.StudentSurname} is in faculty: '{selectedStudent.Faculty.FacultyName}'");
//            Console.WriteLine("Select a faculty to transfer student to: ");

//            UpdateStudentFaculty(ref selectedStudent);

//            //List<Faculty> faculties = FacultyMethods.GetFaculties();
//            //PrintFaculties(faculties);

//            //Console.Write("Enter the number of the faculty: ");
//            //if (!(int.TryParse(Console.ReadLine(), out int facultyId) && facultyId >= 1 && facultyId <= faculties.Count))
//            //{
//            //    do
//            //    {
//            //        Console.WriteLine("Enter the number of the faculty: ");
//            //    } while (int.TryParse(Console.ReadLine(), out facultyId) && facultyId >= 1 && facultyId <= faculties.Count);
//            //}

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
//        public Student GetStudentInputUntilValidated()
//        {
//            Student student;
//            // get initial student info
//            Console.WriteLine("Student Name: ");
//            string studentName = Console.ReadLine();
//            Console.WriteLine("Student Surname: ");
//            string studentSurname = Console.ReadLine();
//            Console.WriteLine("Student Email: ");
//            string studentEmail = Console.ReadLine();
//            Console.WriteLine("Student Number: ");
//            int studentNumber = int.Parse(Console.ReadLine());

//            // repeat loop until all fields are validated
//            do
//            {

//                //var scienceFaculty = new Faculty { FacultyName = "EmptyFaculty", FacultyCode = "TEST01" };
//                //var lecture2 = new Lecture { LectureName = "EmptyLecture" };
//                //List<Lecture> lectures2 = new List<Lecture>();
//                //lectures2.Add(lecture2);

//                student = new Student
//                {
//                    StudentName = studentName,
//                    StudentSurname = studentSurname,
//                    StudentEmail = studentEmail,
//                    StudentNumber = studentNumber,
//                    //Faculty = scienceFaculty,
//                    //Lectures = lectures2
//                };
//                int missingValidation = ValidateStudentInput(student);                              // checks the student validation and returns approprirate int for valid student fields count

//                if (!IsStudentInputValidated(student))
//                {

//                    if (missingValidation == 0)                                                         // all is bad
//                    {
//                        Console.WriteLine("Student information is wrong! Try again!");

//                        Console.WriteLine("Student Name: ");
//                        studentName = Console.ReadLine();
//                        Console.WriteLine("Student Surname: ");
//                        studentSurname = Console.ReadLine();
//                        Console.WriteLine("Student Email: ");
//                        studentEmail = Console.ReadLine();
//                        Console.WriteLine("Student Number: ");
//                        studentNumber = int.Parse(Console.ReadLine());
//                    }
//                    //if (missingValidation == 1)                                                         // all is ok
//                    //{

//                    //}
//                    if (missingValidation == 2)                                                         // only the name is ok 
//                    {
//                        Console.WriteLine("Only the student name is in correct format, please reinsert missing info: Student Surname & Email");

//                        Console.WriteLine("Repeat Student Surname: ");
//                        studentSurname = Console.ReadLine();
//                        Console.WriteLine("Repeat Student Email: ");
//                        studentEmail = Console.ReadLine();
//                    }
//                    if (missingValidation == 3)                                                         // onlt the name and surname is ok, email is wrong
//                    {
//                        Console.WriteLine("Only the student name and surname is in correct format, please reinsert missing info: Student Email");

//                        Console.WriteLine("Repeat Student Email: ");
//                        studentEmail = Console.ReadLine();
//                    }
//                }
//            } while (!IsStudentInputValidated(student));
//            return student;

//        }
//        public bool IsStudentInputValidated(Student student)
//        {
//            if (!(ValidateStudentInput(student) == 1))                                                         // all is ok
//            {
//                return false;
//            }
//            return true;
//        }

//        public int ValidateStudentInput(Student student)
//        {
//            // returns:
//            // 0 - everything is wrong
//            // 1 - everything is validated
//            // 2 - only Name is validated
//            // 3 - name and surname is validated

//            var regexPattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";

//            if (student.StudentName.Length >= 2
//                && student.StudentName.Length <= 50)
//            {
//                if (student.StudentSurname.Length >= 2
//                && student.StudentSurname.Length <= 50)
//                {
//                    if (Regex.IsMatch(student.StudentEmail, regexPattern))
//                    {
//                        return 1;
//                    }
//                    return 3;

//                }
//                // blalala
//                return 2;
//            }
//            return 0;


//        }

//        public void InsertStudentInputToDB(Student student)
//        {
//            var dbContext = new FacultyContext();
//            dbContext.Students.Add(student);
//            dbContext.SaveChanges();
//        }

//        public static List<Lecture> GetLectures()
//        {
//            var dbContext = new FacultyContext();
//            List<Lecture> lectures;
//            return lectures = dbContext.Lectures.ToList();
//        }

//        public List<Lecture> GetLecturesByFaculty()
//        {
//            var dbContext = new FacultyContext();
//            List<Lecture> lectures;
//            //return lectures = dbContext.Lecture.Where(s => s.LectureId == (dbContext.FacultyLectures.Select(l => l.FacultyId == 2)).ToList();
//            return lectures = dbContext.FacultyLectures.Where(fl => fl.FacultyId == 2).Select(fl => fl.Lecture).ToList();
//        }
//    }
//}
