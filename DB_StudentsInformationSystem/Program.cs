using DB_StudentsInformationSystem.Database;
using System.Reflection.Metadata.Ecma335;

namespace DB_StudentsInformationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new FacultyContext();
            //dbContext.Database.EnsureDeleted();
            //Environment.Exit(0);

            //NavigateMenu();

            //var faculty = new FacultyMethods(dbContext);
            //var student = new StudentMethods(dbContext);
            //var lecture = new LectureMethods(dbContext);

            var dbMethods = new DbMethods(dbContext);

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

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //Create Faculty
                        dbMethods.CreateFaculty();
                        Console.ReadKey();
                        break;

                    case "2":
                        //Create And Assign Lectures to Faculty
                        dbMethods.CreateLectureAndAssignToFaculty();
                        Console.ReadKey();
                        break;

                    case "3":
                        //Create Student And Assign To Faculty
                        dbMethods.CreateStudentAndAssignFaculty();                              // returns student object from user input
                        Console.ReadKey();
                        break;

                    case "4":

                        dbMethods.TransferStudentToAnotherFaculty();
                        Console.ReadKey();
                        break;

                    case "5":
                        //Display All Students Of Faculty
                        dbMethods.Printer("5");
                        Console.ReadKey();
                        break;

                    case "6":
                        //Display All Lectures Of Faculty
                        dbMethods.Printer("6");
                        Console.ReadKey();
                        break;

                    case "7":
                        dbMethods.Printer("7");
                        //Display All Lectures By Student
                        Console.ReadKey();
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
        //public enum MenuOptions
        //{
        //    CreateFaculty = 1,
        //    CreateLectureAndAssignToFaculty = 2,
        //    CreateStudentAssignToFacultyAndAddLectures = 3,
        //    ReassignStudent = 4,
        //    PrintStudentsOfFaculty = 5,
        //    PrintLecturesOfFaculty = 6,
        //    PrintLecturesOfStudent = 7,
        //    Exit = 8
        //}
        //static void DrawMenu(string[] options, int selectedIndex)
        //{
        //    string title = "Student Information System";
        //    int windowWidth = Console.WindowWidth;
        //    int windowHeight = Console.WindowHeight;

        //    // Draw the title
        //    int titleX = (windowWidth - title.Length) / 2;
        //    Console.SetCursorPosition(titleX, 2);
        //    Console.WriteLine(title);

        //    // Draw the menu options
        //    for (int i = 0; i < options.Length; i++)
        //    {
        //        int optionX = (windowWidth - options[i].Length) / 2;
        //        int optionY = 7 + i;

        //        Console.SetCursorPosition(optionX, optionY);

        //        if (i == selectedIndex)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Green;
        //            Console.Write(options[i]);
        //            Console.ForegroundColor = ConsoleColor.White;
        //        }
        //        else
        //        {
        //            Console.Write(options[i]);
        //        }
        //    }

        //    // Draw box for title
        //    for (int i = titleX - 1; i < titleX + title.Length + 1; i++)
        //    {
        //        Console.SetCursorPosition(i, 1);
        //        Console.Write("─");
        //        Console.SetCursorPosition(i, 3);
        //        Console.Write("─");
        //    }
        //    Console.SetCursorPosition(titleX - 1, 2);
        //    Console.Write("│");
        //    Console.SetCursorPosition(titleX + title.Length, 2);
        //    Console.Write("│");

        //    Console.SetCursorPosition(titleX - 1, 1);
        //    Console.Write("┌");
        //    Console.SetCursorPosition(titleX + title.Length, 1);
        //    Console.Write("┐");
        //    Console.SetCursorPosition(titleX - 1, 3);
        //    Console.Write("└");
        //    Console.SetCursorPosition(titleX + title.Length, 3);
        //    Console.Write("┘");

        //    // Draw the borders for menu
        //    for (int i = 0; i < windowWidth; i++)
        //    {
        //        Console.SetCursorPosition(i, 4);
        //        Console.Write("─");
        //        Console.SetCursorPosition(i, windowHeight - 2);
        //        Console.Write("─");
        //    }
        //    for (int i = 5; i < windowHeight - 1; i++)
        //    {
        //        Console.SetCursorPosition(0, i);
        //        Console.Write("│");
        //        Console.SetCursorPosition(windowWidth - 1, i);
        //        Console.Write("│");
        //    }
        //    // Draw the corners for menu
        //    Console.SetCursorPosition(0, 4);
        //    Console.Write("┌");
        //    Console.SetCursorPosition(windowWidth - 1, 4);
        //    Console.Write("┐");
        //    Console.SetCursorPosition(0, windowHeight - 2);
        //    Console.Write("└");
        //    Console.SetCursorPosition(windowWidth - 1, windowHeight - 2);
        //    Console.Write("┘");
        //}
        //static void NavigateMenu()
        //{
        //    string[] menuItems = { "1. Create Faculty", "2. Create Lecture and assign it to Faculty", 
        //        "3. Create Student assign it to a Faculty and add Lectures", "4. Reassign Student",
        //        "5. Print Students Of Faculty", "6. Print Lectures of Faculty", "7. Print Lectures of Student",
        //        "8. Exit" };

        //    int selectedIndex = 0;

        //    while (true)
        //    {
        //        DrawMenu(menuItems, selectedIndex);

        //        ConsoleKey key = Console.ReadKey().Key;

        //        switch (key)
        //        {
        //            case ConsoleKey.UpArrow:
        //                selectedIndex = Math.Max(0, selectedIndex - 1);
        //                break;
        //            case ConsoleKey.DownArrow:
        //                selectedIndex = Math.Min(menuItems.Length - 1, selectedIndex + 1);
        //                break;
        //            case ConsoleKey.Enter:
        //                HandleMenuItemSelection(Int32.Parse(menuItems[selectedIndex].Split('.')[0]));
        //                break;
        //        }
        //    }
        //}
        //static void HandleMenuItemSelection(int choice)
        //{
        //    Console.Clear();
        //    // Add logic to handle the selected menu item.
        //    Console.WriteLine($"Selected option: {choice}");
        //    if ((MenuOptions)choice == MenuOptions.CreateFaculty) FacultyMethods.CreateFaculty();
        //    if ((MenuOptions)choice == MenuOptions.CreateLectureAndAssignToFaculty) LectureMethods.CreateLectureAndAssignToFaculty();
        //    if ((MenuOptions)choice == MenuOptions.CreateStudentAssignToFacultyAndAddLectures) StudentMethods.CreateStudentAndAssignFaculty();
        //    if ((MenuOptions)choice == MenuOptions.ReassignStudent) StudentMethods.TransferStudentToAnotherFaculty();
        //    if ((MenuOptions)choice == MenuOptions.PrintStudentsOfFaculty) FacultyMethods.Printer("5");
        //    if ((MenuOptions)choice == MenuOptions.PrintLecturesOfFaculty) FacultyMethods.Printer("6");
        //    if ((MenuOptions)choice == MenuOptions.PrintLecturesOfStudent) FacultyMethods.Printer("7");
        //    if ((MenuOptions)choice == MenuOptions.Exit) Environment.Exit(0);
        //}
        #endregion
        #region PopulateDB
        //public static void PopulateDb()
        //{
        //    var dbContext = new FacultyContext();

        //    dbContext.Database.EnsureDeleted();
        //    dbContext.Database.EnsureCreated();

        //    var scienceFaculty = new Faculty { FacultyName = "Sciences" };
        //    var languageFaculty = new Faculty { FacultyName = "Language" };
        //    var engineerFaculty = new Faculty { FacultyName = "Engineering" };
        //    dbContext.Faculty.AddRange(scienceFaculty, languageFaculty, engineerFaculty);

        //    Lecture lecture1 = new Lecture { LectureName = "Biologija" };
        //    var lecture2 = new Lecture { LectureName = "Matematika" };
        //    var lecture3 = new Lecture { LectureName = "Fizika" };
        //    var lecture4 = new Lecture { LectureName = "Anglu" };
        //    var lecture5 = new Lecture { LectureName = "Daile" };
        //    var lecture6 = new Lecture { LectureName = "Rusu" };
        //    var lecture7 = new Lecture { LectureName = "Lietuviu" };
        //    var lecture8 = new Lecture { LectureName = "Chemija" };

        //    dbContext.Lecture.AddRange(lecture1, lecture2, lecture3, lecture4, lecture5, lecture6, lecture7, lecture8);

        //    List<Lecture> lectures1 = new List<Lecture>();
        //    lectures1.Add(lecture1);
        //    lectures1.Add(lecture3);
        //    lectures1.Add(lecture5);

        //    List<Lecture> lectures2 = new List<Lecture>();
        //    lectures2.Add(lecture2);
        //    lectures2.Add(lecture4);
        //    lectures2.Add(lecture6);

        //    List<Lecture> lectures3 = new List<Lecture>();
        //    lectures3.Add(lecture7);
        //    lectures3.Add(lecture8);

        //    var testStudent1 = new Student { StudentName = "Tomas", StudentSurname = "Babajus", Lectures = lectures1, Faculty = scienceFaculty };
        //    var testStudent2 = new Student { StudentName = "Dinas", StudentSurname = "Karabinas", Lectures = lectures2, Faculty = languageFaculty };
        //    var testStudent3 = new Student { StudentName = "Lukas", StudentSurname = "Bambukas", Lectures = lectures3, Faculty = engineerFaculty };

        //    dbContext.Student.AddRange(testStudent1, testStudent2, testStudent3);


        //    dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = scienceFaculty, Lecture = lecture1 });
        //    dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = scienceFaculty, Lecture = lecture8 });

        //    dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = engineerFaculty, Lecture = lecture2 });
        //    dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = engineerFaculty, Lecture = lecture3 });
        //    dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = engineerFaculty, Lecture = lecture5 });

        //    dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = languageFaculty, Lecture = lecture4 });
        //    dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = languageFaculty, Lecture = lecture6 });
        //    dbContext.FacultyLectures.Add(new FacultyLecture { Faculty = languageFaculty, Lecture = lecture7 });

        //    dbContext.SaveChanges();
        //}
        #endregion
    }
}
