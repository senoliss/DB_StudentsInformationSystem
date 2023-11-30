using DB_StudentsInformationSystem.Database;
using DB_StudentsInformationSystem.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace DB_StudentsInformationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var dbContext = new FacultyContext();
            //dbContext.Database.EnsureDeleted();
            //Environment.Exit(0);

            //NavigateMenu();
            //StudentMethods.GetLecturesByFaculty();
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Student Information System");
                Console.WriteLine("1. Create a faculty.");
                Console.WriteLine("2. Create a lecture and assign it to a faculty.");
                Console.WriteLine("3. Create a student, add to a faculty, and assign lectures");
                Console.WriteLine("4. Transfer student to another faculty");
                Console.WriteLine("5. Display all students of the faculty");
                Console.WriteLine("6. Display all lectures of the faculty");
                Console.WriteLine("7. Display all lectures by student");
                Console.WriteLine("0. Exit");

                //Console.WriteLine("Student Information System");
                //Console.WriteLine("1. Create a faculty and add students/lectures");
                //Console.WriteLine("2. Add students/lectures to an existing faculty");
                //Console.WriteLine("3. Create a lecture and assign it to a faculty");
                //Console.WriteLine("4. Create a student, add to a faculty, and assign lectures");
                //Console.WriteLine("5. Transfer student to another faculty");
                //Console.WriteLine("6. Display all students of the faculty");
                //Console.WriteLine("7. Display all lectures of the faculty");
                //Console.WriteLine("8. Display all lectures by student");
                //Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //Create Faculty
                        FacultyMethods.CreateFaculty();
                        break;

                    case "2":
                        //Create And Assign Lectures to Faculty
                        LectureMethods.CreateLectureAndAssignToFaculty();
                        break;

                    case "3":
                        //Create Student And Assign To Faculty
                        if (StudentMethods.CheckIfAnyFacultyExists())
                        {
                            //ahve to check also if faculty has lessons assigned in FacultyLectures table, otherwie we cannot add student to faculty which has no lessons in it yeet
                            StudentMethods.CreateStudentAndAssignFaculty();                              // returns student object from user input
                        }
                        else Console.WriteLine("No faculties has been created yet! Please create a faculty and then assign students...");
                        break;

                    case "4":
                        //Create Student And Assign To Faculty
                        //if (StudentMethods.CheckIfAnyFacultyExists())
                        //{
                        //    StudentMethods.CreateStudent();                              // returns student object from user input
                        //}
                        //else Console.WriteLine("No faculties has been created yet! Please create a faculty and then assign students...");
                        break;

                    //case "5":
                    //    //Transfer Student To Another Faculty

                    //    break;

                    case "5":
                        //Display All Students Of Faculty
                        FacultyMethods.Printer("5");
                        Console.ReadKey();
                        break;

                    case "6":
                        //Display All Lectures Of Faculty
                        FacultyMethods.Printer("6");
                        Console.ReadKey();
                        break;

                    case "7":
                        //Display All Lectures By Student
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }
        }
        #region Menu
        public enum MenuOptions
        {
            CreateFaculty = 1,
            AssignStudentsAndLectures = 2,
            CreateLecture = 3,
            CreateStudent = 4,
            ReassignStudent = 5,
            PrintStudentsOfFaculty = 6,
            PrintLecturesOfFaculty = 7,
            PrintLecturesOfStudent = 8,
            Exit = 9
        }

        static void DrawMenu(string[] options, int selectedIndex)
        {
            string title = "Student Information System";
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            // Draw the title
            int titleX = (windowWidth - title.Length) / 2;
            Console.SetCursorPosition(titleX, 2);
            Console.WriteLine(title);

            // Draw the menu options
            for (int i = 0; i < options.Length; i++)
            {
                int optionX = (windowWidth - options[i].Length) / 2;
                int optionY = 7 + i;

                Console.SetCursorPosition(optionX, optionY);

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(options[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(options[i]);
                }
            }

            // Draw the borders
            for (int i = 0; i < windowWidth; i++)
            {
                Console.SetCursorPosition(i, 4);
                Console.Write("─");
                Console.SetCursorPosition(i, windowHeight - 2);
                Console.Write("─");
            }
            for (int i = 5; i < windowHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("│");
                Console.SetCursorPosition(windowWidth - 1, i);
                Console.Write("│");
            }

            Console.SetCursorPosition(0, 4);
            Console.Write("┌");
            Console.SetCursorPosition(windowWidth - 1, 4);
            Console.Write("┐");
            Console.SetCursorPosition(0, windowHeight - 2);
            Console.Write("└");
            Console.SetCursorPosition(windowWidth - 1, windowHeight - 2);
            Console.Write("┘");
        }
        static void NavigateMenu()
        {
            string[] menuItems = { "1. Create Faculty", "2. Assign Students And Lectures to Faculty", "3. Create Lecture",
                "4. Create Student", "5. Reassign Student", "6. Print Students Of Faculty", "7. Print Lectures Of Faculty",
                "8. Print Lectures Of Student", "9. Exit" };

            int selectedIndex = 0;

            while (true)
            {
                DrawMenu(menuItems, selectedIndex);

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = Math.Max(0, selectedIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = Math.Min(menuItems.Length - 1, selectedIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        HandleMenuItemSelection(Int32.Parse(menuItems[selectedIndex].Split('.')[0]));
                        break;
                }
            }
        }
        static void HandleMenuItemSelection(int choice)
        {
            Console.Clear();
            // Add logic to handle the selected menu item.
            Console.WriteLine($"Selected option: {choice}");
            if ((MenuOptions)choice == MenuOptions.CreateFaculty) FacultyMethods.CreateFaculty();
            if ((MenuOptions)choice == MenuOptions.AssignStudentsAndLectures) ;
            //if ((MenuOptions)choice == MenuOptions.CreateLecture) LectureMethods.CreateLecture();
            //if ((MenuOptions)choice == MenuOptions.CreateStudent) StudentMethods.CreateStudent();
            if ((MenuOptions)choice == MenuOptions.ReassignStudent) ;
            if ((MenuOptions)choice == MenuOptions.PrintStudentsOfFaculty) FacultyMethods.GetStudents();
            if ((MenuOptions)choice == MenuOptions.PrintLecturesOfFaculty) FacultyMethods.GetLectures();
            if ((MenuOptions)choice == MenuOptions.PrintLecturesOfStudent) StudentMethods.GetLectures();
            if ((MenuOptions)choice == MenuOptions.Exit) Environment.Exit(0);
        }
        #endregion
        public static void PopulateDb()
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

    public class FacultyMethods
    {
        public static bool ConfirmCreatingFaculty(Faculty faculty)
        {
            Console.WriteLine("Faculty will be created with such info: ");
            Console.WriteLine($"Faculty Name: {faculty.FacultyName}");
            Console.WriteLine($"Faculty Code: {faculty.FacultyCode}");
            Console.Write("Do you wish to continue? YES-[y]");

            string choice = Console.ReadLine();

            return choice == "y" ? true : false;
        }
        public static void CreateFaculty()
        {
            Faculty faculty = GetFacultyInput();
            if (IsFacultyInputValidated(faculty))                             // returns bool if student is valid
            {
                if (ConfirmCreatingFaculty(faculty))                          // returns bool on user choice of confirming correct info
                {
                    InsertFacultyInputToDB(faculty);                          // inserts student to DB
                }
            }
        }
        public static Faculty GetFacultyInput()
        {
            //Here we'll get info required to create Departament
            Faculty faculty = new Faculty();

            Console.WriteLine("Enter the name of the Faculty");
            string facName = Console.ReadLine();
            Console.WriteLine("Enter the code of the Faculty");
            string facCode = Console.ReadLine();

            faculty.FacultyName = facName;
            faculty.FacultyCode = facCode;

            return faculty;
        }

        public static void UpdateFaculty(int facultyChosen, int whatToUpdate)
        {
            List<Faculty> faculties = GetFaculties();
            Faculty facultyToUpdate = faculties[facultyChosen];
        }
        public static bool IsFacultyInputValidated(Faculty faculty)
        {
            //Here we'll Validate info that we got from input to create Departament

            if (!(ValidateFacultyInput(faculty) == 1))                                                         // all is ok
            {

                return false;
            }
            return true;
        }
        public static int ValidateFacultyInput(Faculty faculty)
        {
            //Here we'll Validate info that we got from input to create Departament
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
                // blalala
                return 2;
            }
            return 0;
        }

        public static void InsertFacultyInputToDB(Faculty faculty)
        {
            //Here we'll insert the validated Departament info to DB
            var dbContext = new FacultyContext();
            dbContext.Faculty.Add(faculty);
            dbContext.SaveChanges();
        }

        // Gets all the lectures from Lecture DB Table
        public static List<Lecture> GetLectures()
        {
            var dbContext = new FacultyContext();
            List<Lecture> lectures;
            return lectures = dbContext.Lecture.ToList();
        }

        public static List<Lecture> GetLecturesByFaculty(int facultyId)
        {
            var dbContext = new FacultyContext();
            List<Lecture> lectures;
            //return lectures = dbContext.Lecture.Where(s => s.LectureId == (dbContext.FacultyLectures.Select(l => l.FacultyId == 2)).ToList();
            return lectures = dbContext.FacultyLectures.Where(fl => fl.FacultyId == facultyId).Select(fl => fl.Lecture).ToList();
        }

        // Gets all the students from Student DB Table
        public static List<Student> GetStudents()
        {
            var dbContext = new FacultyContext();
            List<Student> students;
            return students = dbContext.Student.ToList();

        }
        public static List<Student> GetStudentsByFaculty(int facultyId)
        {
            var dbContext = new FacultyContext();
            List<Student> students;
            //return lectures = dbContext.Lecture.Where(s => s.LectureId == (dbContext.FacultyLectures.Select(l => l.FacultyId == 2)).ToList();
            return students = dbContext.Student.Where(fl => fl.Faculty.FacultyId == facultyId).ToList();//.Select(fl => fl.Lecture).ToList();
        }

        public static List<Faculty> GetFaculties()
        {
            var dbContext = new FacultyContext();
            List<Faculty> faculties;
            return faculties = dbContext.Faculty.ToList();
        }

        // Prints either lectures or students by choice to the console
        public static void Printer(string choice)
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
                                Console.WriteLine($"{i}. Student: {student.StudentName} {student.StudentSurname} - {student.StudentNumber} - Faculty: {student.Faculty.FacultyId}");
                            }
                            else
                            {

                                Console.WriteLine($"{i}. Student: {student.StudentName} {student.StudentSurname} - {student.StudentNumber}");
                            }
                            i++;
                        }
                    }
                    else Console.WriteLine("There's no students currentlt in this faculty!");
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
            }
        }

        public static void PrintFaculties(List<Faculty> faculties)
        {
            int i = 1;
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"{i}. Faculty: {faculty.FacultyName} - {faculty.FacultyCode}");
                i++;
            }
        }
    }

    public class LectureMethods
    {
        public static void CreateLectureAndAssignToFaculty()
        {
            // Have to have maybe two methods, one for creating students to list without faculty from opt 4, and another to directly create and assign a faculty to it.
            Lecture lectureToInput = GetLectureInput();                // returns student object from user input

            if (ConfirmCreatingLecture(lectureToInput))                             // returns bool if student is valid
            {
                InsertLectureInputToDB(lectureToInput);                              // inserts student to DB
                AssignLectureToFacultyAndUpdateDB(lectureToInput);
            }

        }

        public static Lecture GetLectureInput()
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

        public static bool ConfirmCreatingLecture(Lecture lecture)
        {
            Console.WriteLine("Lecture will be created with such info: ");
            Console.WriteLine($"Lecture Name: {lecture.LectureName}");
            Console.WriteLine($"Lecture start time: {lecture.LectureTimeStart}");
            Console.WriteLine($"Lecture end time: {lecture.LectureTimeEnd}");
            Console.Write("Do you wish to continue? YES-[y]");

            string choice = Console.ReadLine();

            return choice == "y" ? true : false;
        }

        public static void InsertLectureInputToDB(Lecture lecture)
        {
            var dbContext = new FacultyContext();
            dbContext.Lecture.Add(lecture);
            dbContext.SaveChanges();
        }

        public static void AssignLectureToFacultyAndUpdateDB(Lecture lecture)
        {
            List<Faculty> faculties = GetFaculties();
            PrintFaculties(faculties);

            Console.Write($"Enter the number of the faculty to assign lecture {lecture.LectureName}: ");
            if (int.TryParse(Console.ReadLine(), out int facultyNumber) && facultyNumber >= 1 && facultyNumber <= faculties.Count)
            {
                // Subtract 1 to get the correct index in the list
                Faculty selectedFaculty = faculties[facultyNumber - 1];

                // Assign the selected faculty to the student
                var dbContext = new FacultyContext();
                if (selectedFaculty != null && lecture != null)
                {
                    // EF will automatically manage the FacultyLecture table
                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { Faculty = selectedFaculty, Lecture = lecture});
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

        public static void PrintFaculties(List<Faculty> faculties)
        {
            int i = 1;
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"{i}. Faculty: {faculty.FacultyName} - {faculty.FacultyCode}");
                i++;
            }
        }

        public static List<Faculty> GetFaculties()
        {
            var dbContext = new FacultyContext();
            List<Faculty> faculties;
            return faculties = dbContext.Faculty.Include(s => s.FacultyLectures).ToList();
        }
    }

    public class StudentMethods
    {
        public static bool CheckIfAnyFacultyExists()
        {
            List<Faculty> faculties = GetFaculties();

            return faculties.Count > 0;
        }
        public static List<Faculty> GetFaculties()
        {
            var dbContext = new FacultyContext();
            List<Faculty> faculties;
            return faculties = dbContext.Faculty.ToList();
        }
        //public static void DeleteStudent()
        //{
        //    var dbContext = new FacultyContext();
        //    var studentToDelete = dbContext.Student.FirstOrDefault(s => s.Faculty.FacultyCode == "TEST01");
        //    if (studentToDelete != null)
        //    {
        //        dbContext.Student.Remove(studentToDelete);
        //        dbContext.SaveChanges();
        //    }
        //}
        public static void CreateStudentAndAssignFaculty()
        {
            // Have to have maybe two methods, one for creating students to list without faculty from opt 4, and another to directly create and assign a faculty to it.
            Student studentToInput = GetStudentInputUntilValidated();                // returns student object from user input

            if (IsStudentInputValidated(studentToInput))                             // returns bool if student is valid
            {
                UpdateStudentFaculty(ref studentToInput);
                //InsertStudentInputToDB(studentToInput);     // not needed since we add, update and save changes in UpdateStudentFaculty() method
            }
        }
        public static void UpdateStudentFaculty(ref Student student)
        {
            List<Faculty> faculties = GetFaculties();
            PrintFaculties(faculties);


            Console.Write($"Enter the number of the faculty to assign student {student.StudentName} {student.StudentSurname} to: ");
            if (int.TryParse(Console.ReadLine(), out int facultyNumber) && facultyNumber >= 1 && facultyNumber <= faculties.Count)
            {
                // Subtract 1 to get the correct index in the list
                Faculty selectedFaculty = faculties[facultyNumber - 1];

                // Assign the selected faculty to the student
                var dbContext = new FacultyContext();
                if (selectedFaculty != null && student != null)
                {
                    // EF will automatically manage the FacultyLecture table
                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
                    //selectedFaculty.FacultyLectures.Add(new FacultyLecture { Faculty = selectedFaculty, Lecture = lecture});
                    //dbContext.FacultyLectures.Add(new FacultyLecture { FacultyId = selectedFaculty.FacultyId, LectureId = lecture.LectureId });
                    dbContext.Student.Add(student);
                    student.Faculty = selectedFaculty;
                    dbContext.SaveChanges();
                }

                Console.WriteLine($"Student {student.StudentName} {student.StudentSurname} assigned to {selectedFaculty.FacultyName} faculty.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid faculty number.");
            }
        }

        public static void PrintFaculties(List<Faculty> faculties)
        {
            int i = 1;
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"{i}. Faculty: {faculty.FacultyName} - {faculty.FacultyCode}");
                i++;
            }
        }
        public static Student GetStudentInputUntilValidated()
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
        public static bool IsStudentInputValidated(Student student)
        {
            if (!(ValidateStudentInput(student) == 1))                                                         // all is ok
            {
                return false;
            }
            return true;
        }

        public static int ValidateStudentInput(Student student)
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

        public static void InsertStudentInputToDB(Student student)
        {
            var dbContext = new FacultyContext();
            dbContext.Student.Add(student);
            dbContext.SaveChanges();
        }

        public static List<Lecture> GetLectures()
        {
            var dbContext = new FacultyContext();
            List<Lecture> lectures;
            return lectures = dbContext.Lecture.ToList();
        }

        public static List<Lecture> GetLecturesByFaculty()
        {
            var dbContext = new FacultyContext();
            List<Lecture> lectures;
            //return lectures = dbContext.Lecture.Where(s => s.LectureId == (dbContext.FacultyLectures.Select(l => l.FacultyId == 2)).ToList();
            return lectures = dbContext.FacultyLectures.Where(fl => fl.FacultyId == 2).Select(fl => fl.Lecture).ToList();
        }
    }
}
