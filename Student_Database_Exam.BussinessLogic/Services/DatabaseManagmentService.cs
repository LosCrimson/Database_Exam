using Student_Database_Exam.BussinessLogic.Interfaces;
using Student_Database_Exam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Student_Database_Exam.BussinessLogic.Services
{
    public class DatabaseManagmentService : IDatabaseManagmentService
    {
        private readonly IDepartmentService _departmentService;
        private readonly IClassService _classService;
        private readonly IStudentService _studentService;
        DatabaseManagmentService(DepartmentService departmentService, IClassService classService, IStudentService studentService)
        {
            _departmentService = departmentService;
            _classService = classService;
            _studentService = studentService;
        }
        public void CreateDepartmentsForTesting()
        {
            _departmentService.CreateDepartment("Technology");
            _departmentService.CreateDepartment("Science");
            _departmentService.CreateDepartment("Math");
            _departmentService.CreateDepartment("Anarchy");
            _departmentService.CreateDepartment("IT");
        }
        public void CreateClassesForTesting()
        {
            _classService.CreateClassAndAddToDepartment("Math", new List<Department> { _departmentService.GetDepartmentByName("Technology") });
            _classService.CreateClassAndAddToDepartment("English", new List<Department> { _departmentService.GetDepartmentByName("Science") });
            _classService.CreateClassAndAddToDepartment("Physics", new List<Department> { _departmentService.GetDepartmentByName("Math") });
            _classService.CreateClassAndAddToDepartment("Chemistry", new List<Department> { _departmentService.GetDepartmentByName("Anatchy") });
            _classService.CreateClassAndAddToDepartment("Electorincs", new List<Department> { _departmentService.GetDepartmentByName("IT") });
            _classService.CreateClassAndAddToDepartment("Robotics", new List<Department> { _departmentService.GetDepartmentByName("Technology"), _departmentService.GetDepartmentByName("Anarchy") });
            _classService.CreateClassAndAddToDepartment("Philosophy", new List<Department> { _departmentService.GetDepartmentByName("Technology"), _departmentService.GetDepartmentByName("IT") });
            _classService.CreateClassAndAddToDepartment("Nuclear Physics", new List<Department> { _departmentService.GetDepartmentByName("Technology"), _departmentService.GetDepartmentByName("Science") });
            _classService.CreateClassAndAddToDepartment("Molotov Classes", new List<Department> { _departmentService.GetDepartmentByName("Technology"), _departmentService.GetDepartmentByName("Math") });
            _classService.CreateClassAndAddToDepartment("History", new List<Department> { _departmentService.GetDepartmentByName("Technology"), _departmentService.GetDepartmentByName("Anarchy") });
            _classService.CreateClassAndAddToDepartment("Bioligy", new List<Department> { _departmentService.GetDepartmentByName("Technology"), _departmentService.GetDepartmentByName("IT") });
        }
        public void CreateStudentsForTesting()
        {
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Jonas", "Lazdikas", _departmentService.GetDepartmentByName("Technology"));
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Vytenis", "Slepete", _departmentService.GetDepartmentByName("Technology"));
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Povilas", "Seilius", _departmentService.GetDepartmentByName("Science"));
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Kastytis", "Grossmann", _departmentService.GetDepartmentByName("Science"));
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Vidmantas", "Reutner", _departmentService.GetDepartmentByName("Math"));
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Haroldas", "Schnaithmann", _departmentService.GetDepartmentByName("Math"));
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Bobikas", "Baumann", _departmentService.GetDepartmentByName("Anarchy"));
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Stenlis", "King", _departmentService.GetDepartmentByName("Anarchy"));
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Piteris", "Karalius", _departmentService.GetDepartmentByName("IT"));
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Trevoras", "Duck", _departmentService.GetDepartmentByName("IT"));
            _studentService.CreateStudentAndAddtoDepartmentWithClasses("Paskalis", "Floorboard", _departmentService.GetDepartmentByName("Anarchy"));
        }
        public void AskUserToCreateTestingDatabase()
        {
            Console.WriteLine("Would you like to populate the database with testing values?");
            Console.WriteLine("[1] YES [2] No");
            int userAnswer = 2;
            try
            {
                userAnswer = int.Parse(Console.ReadLine());
            }
            catch { Console.WriteLine("Invalid input so selecting No[2].");}
            if (userAnswer == 1) 
            {
                CreateDepartmentsForTesting();
                CreateClassesForTesting();
                CreateStudentsForTesting();
                Console.WriteLine("Database populated.");
            }
            else { Console.WriteLine("Database not populated."); }
        }
        public void AsKUserAboutDbSettings()
        {
            // Load the appsettings.json file
            string path = "../Student_Database_Exam/appsettings.json";
            JObject appSettings = JObject.Parse(File.ReadAllText(path));

            // Get the default connection string
            JToken defaultConnection = appSettings["ConnectionStrings"]["DefaultConnection"];

            // Prompt the user for a new server name if necessary
            string defaultServerName = "(localdb)\\Bankomat";
            Console.Write($"Do you want to use the default server name ({defaultServerName})? (y/n)");
            string choice = Console.ReadLine().ToLower();
            string newServerName = "(localdb)\\Bankomat";

            if (choice == "n")
            {
                Console.Write("Please enter a new server name: ");
                newServerName = Console.ReadLine();
            }

            // Update the server name in the connection string
            string connectionString = defaultConnection.ToString();
            connectionString = connectionString.Replace(defaultServerName, newServerName);
            appSettings["ConnectionStrings"]["DefaultConnection"] = connectionString;

            // Save the updated appsettings.json file
            File.WriteAllText(path, appSettings.ToString());

            Console.WriteLine($"Using new server name {newServerName}...");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
