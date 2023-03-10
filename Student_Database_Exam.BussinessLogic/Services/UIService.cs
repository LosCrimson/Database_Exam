using Student_Database_Exam.BussinessLogic.Interfaces;
using Student_Database_Exam.Repository.Enum;
using Student_Database_Exam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.BussinessLogic.Services
{
    public class UIService : IUIService
    {
        private readonly IDepartmentService _departmentService;
        private readonly IClassService _classService;
        private readonly IStudentService _studentService;
        public UIService(DepartmentService departmentService, IClassService classService, IStudentService studentService)
        {
            _departmentService = departmentService;
            _classService = classService;
            _studentService = studentService;
        }
        public void AddStudentsAndOrClassesToDepartment()
        {
            throw new NotImplementedException();
        }

        public void CreateClassAndAddToDepartment()
        {
            throw new NotImplementedException();
        }

        public void CreateDepartment()
        {
            try
                {
                //Print the list of departmens so that the user would see the change.
                Console.WriteLine($"-----------------------------------------");
                PrintAllDepartments(_departmentService.GetDepartmentsList());
                Console.WriteLine("Please enter name of new department: ");
                string newDepartmentName = Console.ReadLine();
                _departmentService.CreateDepartment(newDepartmentName);
                Console.WriteLine($"-----------------------------------------");
                PrintAllDepartments(_departmentService.GetDepartmentsList());
            }
            catch { Console.WriteLine("Something went wrong");}
        }

        public void CreateStudentAndAddtoDepartmentWithClasses()
        {
            throw new NotImplementedException();
        }

        public ActionTypes GetActionType()
        {
            do
            {
                Console.WriteLine("Pick an option: ");
                Console.WriteLine("[1] Show all students in a department.");
                Console.WriteLine("[2] Show all classes in a department.");
                Console.WriteLine("[3] Show all classes of a student.");
                Console.WriteLine("[4] Create department.");
                Console.WriteLine("[5] Add students or classes to depratment.");
                Console.WriteLine("[6] Create class and add to department.");
                Console.WriteLine("[7] Create student and add to department.(Classes assigned automatically)");
                Console.WriteLine("[8] Move student to another department. (Classes assigned automatically)");
                Console.WriteLine("[9] EXIT");

                string? menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        return ActionTypes.ShowAllStudentsInDepartment;
                    case "2":
                        return ActionTypes.ShowAllClassesInDepartment;
                    case "3":
                        return ActionTypes.ShowAllClassesOfStudent;
                    case "4":
                        return ActionTypes.CreateDepartment;
                    case "5":
                        return ActionTypes.AddStudentsAndOrClassesToDepartment;
                    case "6":
                        return ActionTypes.CreateClassAndAddToDepartment;
                    case "7":
                        return ActionTypes.CreateStudentAndAddtoDepartmentWithClasses;
                    case "8":
                        return ActionTypes.MoveStudentToAnotherDepartment;
                    case "9":
                        return ActionTypes.EXIT;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            }
            while (true);
        }

        public void MoveStudentToAnotherDepartment()
        {
            throw new NotImplementedException();
        }

        public void ShowAllClassesInDepartment()
        {
            try
            {
                Console.WriteLine($"-----------------------------------------");
                PrintAllDepartments(_departmentService.GetDepartmentsList());
                Console.WriteLine("Enter name of department you want to see the classes of:");
                string departmentName = Console.ReadLine();
                var department = _departmentService.GetDepartmentByName(departmentName);
                PrintAllClasses(department.Classes);
            }
            catch { Console.WriteLine("This department is not valid or does not exist"); }
        }
        public void PrintAllClasses(List<Class> classes) 
        {
            foreach (var classItem in classes)
            {
                Console.WriteLine($"[{classItem.Id}] {classItem.Name}");
            }
            Console.WriteLine($"-----------------------------------------");
        }

        public void ShowAllClassesOfStudent()
        {
            try
            {
                Console.WriteLine($"-----------------------------------------");
                PrintAllStudents(_studentService.GetStudentsList());
                Console.WriteLine("Enter name of student you want to see the Classes of:");
                string studentName = Console.ReadLine();
                var student = _studentService.GetStudentByName(studentName);
                PrintAllClasses(student.Classes);
            }
            catch { Console.WriteLine("This student is not valid or does not exist"); }
        }

        public void ShowAllStudentsInDepartment()
        {
            try
            {
                Console.WriteLine($"-----------------------------------------");
                PrintAllDepartments(_departmentService.GetDepartmentsList());
                Console.WriteLine("Enter name of department you want to see the Students of:");
                string departmentName = Console.ReadLine();
                var department = _departmentService.GetDepartmentByName(departmentName);
                PrintAllStudents(department.Students);
            }
            catch { Console.WriteLine("This department is not valid or does not exist"); }
        }
        public void PrintAllStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"[{student.Id}] {student.Name} {student.LastName} Department: {student.DepartmentOfStudent}");
            }
            Console.WriteLine($"-----------------------------------------");
        }
        public void PrintAllDepartments(List<Department> departments)
        {
            foreach (var department in departments)
            {
                Console.WriteLine($"[{department.Id}] Department of: {department.Name}");
            }
            Console.WriteLine($"-----------------------------------------");
        }
    }
}
