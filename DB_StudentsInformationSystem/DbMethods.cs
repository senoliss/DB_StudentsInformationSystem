using DB_StudentsInformationSystem.Database;
using DB_StudentsInformationSystem.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DB_StudentsInformationSystem
{
    public class DbMethods
    {
        public FacultyContext dbContext { get; set; }
        public DbMethods(FacultyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region FacultyMethods

        // Master method for Creating Faculty that combines rest methods
        public void CreateFaculty()
        {
            Faculty faculty = GetFacultyInput();
            
            if (IsFacultyInputValidated(faculty))                             // returns bool if faculty is valid
            {
                if (ConfirmCreatingFaculty(faculty))                          // returns bool on user choice of confirming correct info
                {
                    InsertFacultyInputToDB(faculty);                          // inserts faculty to DB
                }
            }
        }
        // Here we'll get info required to create Departament
        public Faculty GetFacultyInput()
        {
            Faculty faculty = new Faculty();

            Console.WriteLine("Enter the name of the Faculty");
            string facName = Console.ReadLine();
            Console.WriteLine("Enter the code of the Faculty");
            string facCode = Console.ReadLine();

            faculty.FacultyName = facName;
            faculty.FacultyCode = facCode;

            return faculty;
        }
        // Here we'll Validate info that we got from input to create Departament
        public int ValidateFacultyInput(Faculty faculty)
        {
            // returns:
            // 0 - everything is wrong
            // 1 - everything is validated
            // 2 - only Name is validated
            if (faculty.FacultyName.Length >= 3
                && faculty.FacultyName.Length <= 100)
            {
                if (faculty.FacultyCode.Length == 6
                    && faculty.FacultyCode.Any(char.IsLetter)
                    && faculty.FacultyCode.Any(char.IsDigit))
                {
                    return 1;
                }
                return 2;
            }
            return 0;
            // magic numbers negali buti, validatoriai turi grazinti konkrecias vertes true false
        }
        // Here we'll Validate info that we got from input to create Departament
        public bool IsFacultyInputValidated(Faculty faculty)
        {
            if (!(ValidateFacultyInput(faculty) == 1))                                                         // all is ok
            {
                return false;
            }
            return true;
        }
        // Asks user if he confirms creating faculty by repeating info
        public bool ConfirmCreatingFaculty(Faculty faculty)
        {
            Console.WriteLine("Faculty will be created with such info: ");
            Console.WriteLine($"Faculty Name: {faculty.FacultyName}");
            Console.WriteLine($"Faculty Code: {faculty.FacultyCode}");
            Console.Write("Do you wish to continue? YES-[y]");

            string choice = Console.ReadLine();

            return choice == "y" ? true : false;
        }
        // idk yet
        public void UpdateFaculty(int facultyChosen, int whatToUpdate)
        {
            List<Faculty> faculties = GetFaculties();
            Faculty facultyToUpdate = faculties[facultyChosen];
        }
        // Here we'll insert the validated Departament info to DB
        public void InsertFacultyInputToDB(Faculty faculty)
        {
            dbContext.Faculties.Add(faculty);
            dbContext.SaveChanges();
        }
        public bool CheckIfAnyFacultyExists()
        {
            List<Faculty> faculties = GetFaculties();
            return faculties.Count > 0;
        }
        public List<Faculty> GetFaculties()
        {
            List<Faculty> faculties;
            return faculties = dbContext.Faculties.Include(s => s.FacultyLectures).ToList();
        }
        // Prints either lectures or students by choice to the console
        public void Printer(string choice)
        {
            int i = 1;
            if (!string.IsNullOrEmpty(choice))
            {
                if (choice == "5")
                {
                    List<Faculty> faculties = GetFaculties();
                    PrintFaculties(faculties);
                    Console.Write("Enter the number of the faculty: ");
                    if (!(int.TryParse(Console.ReadLine(), out int facultyId) && facultyId >= 1 && facultyId <= faculties.Count))
                    {
                        do
                        {
                            Console.WriteLine("Enter the number of the faculty: ");
                        } while (int.TryParse(Console.ReadLine(), out facultyId) && facultyId >= 1 && facultyId <= faculties.Count);
                    }

                    List<Student> students = GetStudentsByFaculty(facultyId);

                    if (students.Count > 0)
                    {

                        foreach (Student student in students)
                        {
                            if (student.Faculty.FacultyId != null)
                            {
                                Console.WriteLine($"{i}. Student: {student.StudentName} {student.StudentSurname} - {student.StudentNumber} - Faculty: {student.Faculty.FacultyName}");
                            }
                            else
                            {

                                Console.WriteLine($"{i}. Student: {student.StudentName} {student.StudentSurname} - {student.StudentNumber}");
                            }
                            i++;
                        }
                    }
                    else Console.WriteLine("There's no students currently in this faculty!");
                }
                else if (choice == "6")
                {
                    List<Faculty> faculties = GetFaculties();
                    PrintFaculties(faculties);
                    Console.Write("Enter the number of the faculty: ");
                    if (!(int.TryParse(Console.ReadLine(), out int facultyId) && facultyId >= 1 && facultyId <= faculties.Count))
                    {
                        do
                        {
                            Console.WriteLine("Enter the number of the faculty: ");
                        } while (int.TryParse(Console.ReadLine(), out facultyId) && facultyId >= 1 && facultyId <= faculties.Count);
                    }

                    List<Lecture> lectures = GetLecturesByFaculty(facultyId);

                    if (lectures.Count > 0)
                    {
                        foreach (Lecture lecture in lectures)
                        {
                            Console.WriteLine($"{i}. Lecture: {lecture.LectureName} - starts: {lecture.LectureTimeStart} / ends: {lecture.LectureTimeEnd} | Faculty: {faculties.FirstOrDefault(f => f.FacultyId == facultyId).FacultyName}");
                            i++;
                        }
                    }
                    else Console.WriteLine("There's no lectures currently in this faculty!");
                }
                else if (choice == "7")
                {
                    List<Student> students = GetStudents();
                    PrintStudents(students);
                    Console.Write("Enter the number of the student: ");
                    if (!(int.TryParse(Console.ReadLine(), out int studentId) && studentId >= 1 && studentId <= students.Count))
                    {
                        do
                        {
                            Console.WriteLine("Enter the number of the faculty: ");
                        } while (int.TryParse(Console.ReadLine(), out studentId) && studentId >= 1 && studentId <= students.Count);
                    }

                    Student selectedStudent = students[studentId - 1];

                    try
                    {
                        List<Lecture> lectures = dbContext.StudentLectures.Where(sl => sl.StudentId == selectedStudent.StudentId).Select(sl => sl.Lecture).ToList(); //GetLecturesByFaculty(selectedStudent.Faculty.FacultyId);
                        if (lectures.Count > 0)
                        {
                            Console.WriteLine($"Student {selectedStudent.StudentName} {selectedStudent.StudentName} lectures: ");
                            foreach (Lecture lecture in lectures)
                            {
                                Console.WriteLine($"{i}. Lecture: {lecture.LectureName} - starts: {lecture.LectureTimeStart} / ends: {lecture.LectureTimeEnd} | Faculty: {selectedStudent.Faculty.FacultyName}");
                                i++;
                            }
                        }
                        else Console.WriteLine($"Although student is appointed to '{selectedStudent.Faculty.FacultyName}' faculty... \nThere's no lectures currently in this faculty!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Although student is appointed to {selectedStudent.Faculty.FacultyName} faculty... \nThere's no lectures currently in this faculty!");
                    }
                }
            }
        }
        // Prints all the faculties from Faculties DB Table
        public void PrintFaculties(List<Faculty> faculties)
        {
            int i = 1;
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"{i}. Faculty: {faculty.FacultyName} - {faculty.FacultyCode}");
                i++;
            }
        }

        #endregion

        #region LectureMethods

        public void CreateLectureAndAssignToFaculty()
        {
            // Have to have maybe two methods, one for creating students to list without faculty from opt 4, and another to directly create and assign a faculty to it.
            Lecture lectureToInput = GetLectureInput();                // returns student object from user input

            if (ConfirmCreatingLecture(lectureToInput))                             // returns bool if student is valid
            {
                InsertLectureInputToDB(lectureToInput);                              // inserts student to DB
                AssignLectureToFacultyAndUpdateDB(lectureToInput);
            }

        }
        public Lecture GetLectureInput()
        {
            //Here we'll get info required to create Lecture and validate the lecture time in the same method
            Lecture lecture = new Lecture();

            Console.WriteLine("Enter the name of the Lecture");
            string lecName = Console.ReadLine();

            // Get and validate lecture start time
            DateTime lecStartTime;
            do
            {
                Console.WriteLine($"At what time lecture {lecName} starts? (HH:mm)");
                string startTimeInput = Console.ReadLine();

                if (DateTime.TryParseExact(startTimeInput, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out lecStartTime))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid time format. Please enter the time in HH:mm format.");
                }
            } while (true);

            // Get and validate lecture end time
            DateTime lecEndTime;
            do
            {
                Console.WriteLine($"At what time lecture {lecName} ends? (HH:mm)");
                string endTimeInput = Console.ReadLine();

                if (DateTime.TryParseExact(endTimeInput, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out lecEndTime))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid time format. Please enter the time in HH:mm format.");
                }
            } while (true);

            lecture.LectureName = lecName;
            lecture.LectureTimeStart = lecStartTime;
            lecture.LectureTimeEnd = lecEndTime;

            return lecture;
        }
        public bool ConfirmCreatingLecture(Lecture lecture)
        {
            Console.WriteLine("Lecture will be created with such info: ");
            Console.WriteLine($"Lecture Name: {lecture.LectureName}");
            Console.WriteLine($"Lecture start time: {lecture.LectureTimeStart}");
            Console.WriteLine($"Lecture end time: {lecture.LectureTimeEnd}");
            Console.Write("Do you wish to continue? YES-[y]");

            string choice = Console.ReadLine();

            return choice == "y" ? true : false;
        }
        public void InsertLectureInputToDB(Lecture lecture)
        {
            //var dbContext = new FacultyContext();
            dbContext.Lectures.Add(lecture);
            dbContext.SaveChanges();
        }
        public void AssignLectureToFacultyAndUpdateDB(Lecture lecture)
        {
            List<Faculty> faculties = GetFaculties();
            PrintFaculties(faculties);

            Console.Write($"Enter the number of the faculty to assign lecture {lecture.LectureName}: ");
            if (int.TryParse(Console.ReadLine(), out int facultyNumber) && facultyNumber >= 1 && facultyNumber <= faculties.Count)
            {
                // Subtract 1 to get the correct index in the list
                Faculty selectedFaculty = faculties[facultyNumber - 1];

                // Assign the selected faculty to the student
                if (selectedFaculty != null && lecture != null)
                {
                    dbContext.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
                    dbContext.SaveChanges();
                }

                Console.WriteLine($"Lecture {lecture.LectureName} assigned to {selectedFaculty.FacultyName} faculty.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid faculty number.");
            }
        }
        // Gets all the lectures from Lecture DB Table
        public List<Lecture> GetLectures()
        {
            List<Lecture> lectures;
            return lectures = dbContext.Lectures.ToList();
        }
        // Gets all the lectures from Lecture DB Table by 'facultyId' prop from Faculty object model
        public List<Lecture> GetLecturesByFaculty(int facultyId)
        {
            List<Lecture> lectures;
            return lectures = dbContext.FacultyLectures.Where(fl => fl.FacultyId == facultyId).Select(fl => fl.Lecture).ToList();
        }
        // Prints all the lectures from Lectures DB Table
        public void PrintLectures(List<Lecture> lectures)
        {
            int i = 1;
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{i}. Lecture: {lecture.LectureName}");
                i++;
            }
        }

        #endregion

        #region StudentMethods

        public void CreateStudentAndAssignFaculty()
        {
            // Have to have maybe two methods, one for creating students to list without faculty from opt 4, and another to directly create and assign a faculty to it.
            if (CheckIfAnyFacultyExists())
            {
                Student studentToInput = GetStudentInputUntilValidated();                // returns student object from user input

                if (IsStudentInputValidated(studentToInput))                             // returns bool if student is valid
                {
                    AddStudentToFaculty(ref studentToInput);
                    AddFacultyLecturesToStudent(studentToInput);
                    //dbContext.SaveChanges();
                    //InsertStudentInputToDB(studentToInput);     // not needed since we add, update and save changes in UpdateStudentFaculty() method
                }//need to ahve method to add lectures to student from facultylecture table
            }
            else Console.WriteLine("No faculties has been created yet! Please create a faculty and then assign students...");
        }
        public void AddStudentToFaculty(ref Student student)
        {
            List<Faculty> faculties = GetFaculties();
            PrintFaculties(faculties);


            Console.Write($"Enter the number of the faculty to assign student {student.StudentName} {student.StudentSurname} to: ");
            if (int.TryParse(Console.ReadLine(), out int facultyNumber) && facultyNumber >= 1 && facultyNumber <= faculties.Count)
            {
                // Subtract 1 to get the correct index in the list
                Faculty selectedFaculty = faculties[facultyNumber - 1];

                // Assign the selected faculty to the student
                //var dbContext = new FacultyContext();
                if (selectedFaculty != null && student != null)
                {
                    // EF will automatically manage the FacultyLecture table
                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { Faculty = selectedFaculty, Lecture = lecture});
                    //dbContext.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
                    student.FacultyId = selectedFaculty.FacultyId;
                    dbContext.Students.Add(student);
                    dbContext.SaveChanges();
                }

                Console.WriteLine($"Student {student.StudentName} {student.StudentSurname} assigned to {selectedFaculty.FacultyName} faculty.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid faculty number.");
            }
        }
        public void AddFacultyLecturesToStudent(Student student)
        {
            Faculty faculty = student.Faculty;
            List<Lecture> lectures = GetLecturesByFaculty(student.FacultyId);

            foreach (Lecture lecture in lectures)
            {
                dbContext.StudentLectures.Add(new StudentLecture { StudentId = student.StudentId, LectureId = lecture.LectureId });
            }
            dbContext.SaveChanges();
        }
        public void UpdateStudentFaculty(ref Student student)
        {
            List<Faculty> faculties = GetFaculties();
            PrintFaculties(faculties);

            var studentToUpdate = dbContext.Students.Find(student.StudentId);        // Finds the new student object without fetching faculty by existing student object studentId

            Console.Write($"Enter the number of the faculty to assign student {student.StudentName} {student.StudentSurname} to: ");
            if (int.TryParse(Console.ReadLine(), out int facultyNumber) && facultyNumber >= 1 && facultyNumber <= faculties.Count)
            {
                // Subtract 1 to get the correct index in the list
                Faculty selectedFaculty = faculties[facultyNumber - 1];

                // Assign the selected faculty to the student
                if (selectedFaculty != null && student != null)
                {
                    studentToUpdate.Faculty = selectedFaculty;      // Updates existing student in db with overrwritend faculty data
                    dbContext.SaveChanges();
                }

                Console.WriteLine($"Student {student.StudentName} {student.StudentSurname} assigned to {selectedFaculty.FacultyName} faculty.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid faculty number.");
            }
        }
        public void TransferStudentToAnotherFaculty()
        {
            List<Student> students = GetStudents();
            Console.WriteLine("Select student to change faculties: ");
            PrintStudents(students);

            if (!(int.TryParse(Console.ReadLine(), out int studentId) && studentId >= 1 && studentId <= students.Count))
            {
                do
                {
                    Console.WriteLine("Enter the number of the faculty: ");
                } while (int.TryParse(Console.ReadLine(), out studentId) && studentId >= 1 && studentId <= students.Count);
            }

            Student selectedStudent = students[studentId - 1];
            Console.WriteLine($"Selected student: {selectedStudent.StudentName} {selectedStudent.StudentSurname} is in faculty: '{selectedStudent.Faculty.FacultyName}'");
            Console.WriteLine("Select a faculty to transfer student to: ");

            UpdateStudentFaculty(ref selectedStudent);
        }
        public Student GetStudentInputUntilValidated()
        {
            Student student;
            // get initial student info
            Console.WriteLine("Student Name: ");
            string studentName = Console.ReadLine();
            Console.WriteLine("Student Surname: ");
            string studentSurname = Console.ReadLine();
            Console.WriteLine("Student Email: ");
            string studentEmail = Console.ReadLine();
            Console.WriteLine("Student Number: ");
            int studentNumber = Int32.Parse(Console.ReadLine());

            // repeat loop until all fields are validated
            do
            {

                //var scienceFaculty = new Faculty { FacultyName = "EmptyFaculty", FacultyCode = "TEST01" };
                //var lecture2 = new Lecture { LectureName = "EmptyLecture" };
                //List<Lecture> lectures2 = new List<Lecture>();
                //lectures2.Add(lecture2);

                student = new Student
                {
                    StudentName = studentName,
                    StudentSurname = studentSurname,
                    StudentEmail = studentEmail,
                    StudentNumber = studentNumber,
                    //Faculty = scienceFaculty,
                    //Lectures = lectures2
                };
                int missingValidation = ValidateStudentInput(student);                              // checks the student validation and returns approprirate int for valid student fields count

                if (!IsStudentInputValidated(student))
                {

                    if (missingValidation == 0)                                                         // all is bad
                    {
                        Console.WriteLine("Student information is wrong! Try again!");

                        Console.WriteLine("Student Name: ");
                        studentName = Console.ReadLine();
                        Console.WriteLine("Student Surname: ");
                        studentSurname = Console.ReadLine();
                        Console.WriteLine("Student Email: ");
                        studentEmail = Console.ReadLine();
                        Console.WriteLine("Student Number: ");
                        studentNumber = Int32.Parse(Console.ReadLine());
                    }
                    //if (missingValidation == 1)                                                         // all is ok
                    //{

                    //}
                    if (missingValidation == 2)                                                         // only the name is ok 
                    {
                        Console.WriteLine("Only the student name is in correct format, please reinsert missing info: Student Surname & Email");

                        Console.WriteLine("Repeat Student Surname: ");
                        studentSurname = Console.ReadLine();
                        Console.WriteLine("Repeat Student Email: ");
                        studentEmail = Console.ReadLine();
                    }
                    if (missingValidation == 3)                                                         // onlt the name and surname is ok, email is wrong
                    {
                        Console.WriteLine("Only the student name and surname is in correct format, please reinsert missing info: Student Email");

                        Console.WriteLine("Repeat Student Email: ");
                        studentEmail = Console.ReadLine();
                    }
                }
            } while (!IsStudentInputValidated(student));
            return student;

        }
        public bool ConfirmCreatingStudent(Student student)
        {
            Console.WriteLine("Student will be created with such info: ");
            Console.WriteLine($"Student Name: {student.StudentName} {student.StudentSurname}");
            Console.WriteLine($"Student Faculty: {student.Faculty.FacultyName} - {student.Faculty.FacultyId}");
            Console.Write("Do you wish to continue? YES-[y]");

            string choice = Console.ReadLine();

            return choice == "y" ? true : false;
        } //not used yet
        public bool IsStudentInputValidated(Student student)
        {
            if (!(ValidateStudentInput(student) == 1))                                                         // all is ok
            {
                return false;
            }
            return true;
        }
        public int ValidateStudentInput(Student student)
        {
            // returns:
            // 0 - everything is wrong
            // 1 - everything is validated
            // 2 - only Name is validated
            // 3 - name and surname is validated

            var regexPattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";

            if (student.StudentName.Length >= 2
                && student.StudentName.Length <= 50)
            {
                if (student.StudentSurname.Length >= 2
                && student.StudentSurname.Length <= 50)
                {
                    if (Regex.IsMatch(student.StudentEmail, regexPattern))
                    {
                        return 1;
                    }
                    return 3;

                }
                // blalala
                return 2;
            }
            return 0;
        }
        public void InsertStudentInputToDB(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }
        // Gets all the students from Student DB Table
        public List<Student> GetStudents()
        {
            List<Student> students;
            return students = dbContext.Students.Include(s => s.Faculty).ToList();

        }
        // Gets all the students from Student DB Table by 'facultyId' prop from Faculty object model
        public List<Student> GetStudentsByFaculty(int facultyId)
        {
            List<Student> students;
            return students = dbContext.Students.Where(fl => fl.Faculty.FacultyId == facultyId).Include(s => s.Faculty).ToList();
        }
        // Prints all the students from Students DB Table
        public void PrintStudents(List<Student> students)
        {
            int i = 1;
            foreach (var student in students)
            {
                Console.WriteLine($"{i}. Student: {student.StudentName} {student.StudentName}");
                i++;
            }
        }

        #endregion
    }
}
