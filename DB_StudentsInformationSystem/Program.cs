using DB_StudentsInformationSystem.Database;
using System.Reflection.Metadata.Ecma335;

namespace DB_StudentsInformationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new FacultyContext();

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
    }
}
