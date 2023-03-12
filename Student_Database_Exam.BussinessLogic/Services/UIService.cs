using Student_Database_Exam.BussinessLogic.Interfaces;
using Student_Database_Exam.Repository.Enum;
using Student_Database_Exam.Repository.Models;

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
            try
            {
                Console.WriteLine($"Do you want to add [1]Students or [2]Classes to department?");
                Console.WriteLine($"Please enter the option number: ");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    try
                    {
                        //Add students
                        Console.WriteLine($"-----------------------------------------");
                        PrintAllStudents(_studentService.GetStudentsList());
                        Console.WriteLine("Please select students which will bee added: ");
                        Console.WriteLine("By writing the ID's");
                        var studentIdList = new List<int>();
                        while (true)
                        {
                            try
                            {
                                int studentId = int.Parse(Console.ReadLine());
                                studentIdList.Add(studentId);
                                Console.WriteLine("Press enter to stop.");
                            }
                            catch { break; }
                        }
                        studentIdList.Distinct();
                        studentIdList.RemoveAll(x => x > _studentService.GetStudentsList().Count);
                        studentIdList.Sort();
                        Console.WriteLine("Duplicates were removed and non existant Id's as well.");
                        Console.WriteLine("Here is the list: ");
                        var studentList = new List<Student>();
                        foreach (int studentId in studentIdList)
                        {
                            var student = _studentService.GetStudentById(studentId);
                            studentList.Add(student);
                        }
                        Console.WriteLine($"-----------------------------------------");
                        PrintAllStudents(studentList);
                        Console.WriteLine("Please enter department number you want the students to be added to: ");
                        Console.WriteLine($"-----------------------------------------");
                        PrintAllDepartments(_departmentService.GetDepartmentsList());
                        Department department = new Department();
                        try
                        {
                            int departmentId = int.Parse(Console.ReadLine());
                            department = _departmentService.GetDepartmentById(departmentId);
                        }
                        catch
                        { Console.WriteLine("Something went wrong selecting Department."); }
                        _studentService.AddStudentsToDepartment(studentList, department);
                        Console.WriteLine($"-----------------------------------------");
                        PrintAllStudents(department.Students);
                    }
                    catch { Console.WriteLine($"Something went wrong adding Students"); }
                }
                else if (option == "2")
                {
                    try
                    {
                        //Add classes
                        Console.WriteLine($"-----------------------------------------");
                        PrintAllClasses(_classService.GetClassesList());
                        Console.WriteLine("Please select classes which will bee added: ");
                        Console.WriteLine("By writing the ID's");
                        var classIdList = new List<int>();
                        while (true)
                        {
                            try
                            {
                                int classId = int.Parse(Console.ReadLine());
                                classIdList.Add(classId);
                                Console.WriteLine("Press enter to stop.");
                            }
                            catch { break; }
                        }
                        classIdList.Distinct();
                        classIdList.RemoveAll(x => x > _classService.GetClassesList().Count);
                        classIdList.Sort();
                        Console.WriteLine("Duplicates were removed and non existant Id's as well.");
                        Console.WriteLine("Here is the list: ");
                        var classList = new List<Class>();
                        foreach (int classId in classIdList)
                        {
                            var classItem = _classService.GetClassById(classId);
                            classList.Add(classItem);
                        }
                        Console.WriteLine($"-----------------------------------------");
                        PrintAllClasses(classList);
                        Console.WriteLine("Please enter department number you want the classes to be added to: ");
                        Console.WriteLine($"-----------------------------------------");
                        PrintAllDepartments(_departmentService.GetDepartmentsList());
                        Department department = new Department();
                        try
                        {
                            int departmentId = int.Parse(Console.ReadLine());
                            department = _departmentService.GetDepartmentById(departmentId);
                        }
                        catch
                        { Console.WriteLine("Something went wrong selecting Department."); }
                        _classService.AddClassessToDepartment(classList, department);
                        Console.WriteLine($"-----------------------------------------");
                        PrintAllClasses(department.Classes);
                    }
                    catch { Console.WriteLine($"Something went wrong adding Classes"); }
                }
            }
            catch { Console.WriteLine($"Something went wrong salecting option"); }
        }

        public void CreateClassAndAddToDepartment()
        {
            Console.WriteLine("Please enter new class name");
            string newClassName = Console.ReadLine();
            Console.WriteLine($"-----------------------------------------");
            PrintAllDepartments(_departmentService.GetDepartmentsList());
            Console.WriteLine("Please select departments to which the new class will be added: ");
            Console.WriteLine("By writing the ID's");
            var departmentIdList = new List<int>();
            while (true)
            {
                try
                {
                    int departmentId = int.Parse(Console.ReadLine());
                    departmentIdList.Add(departmentId);
                    Console.WriteLine("Press enter to stop.");
                }
                catch { break; }
            }
            departmentIdList.Distinct();
            departmentIdList.RemoveAll(x => x > _departmentService.GetDepartmentsList().Count);
            departmentIdList.Sort();
            Console.WriteLine("Duplicates were removed and non existant Id's as well.");
            Console.WriteLine("Here is the list: ");
            var departmentList = new List<Department>();
            foreach (int departmentId in departmentIdList)
            {
                var department = _departmentService.GetDepartmentById(departmentId);
                departmentList.Add(department);
            }
            Console.WriteLine($"-----------------------------------------");
            PrintAllDepartments(departmentList);
            _classService.CreateClassAndAddToDepartment(newClassName, departmentList);
            Console.WriteLine($"New class {newClassName} created");
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
            catch { Console.WriteLine("Something went wrong"); }
        }

        public void CreateStudentAndAddtoDepartmentWithClasses()
        {
            Console.WriteLine("Please enter the name of new student: ");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter the lastname of new student: ");
            var lastname = Console.ReadLine();
            Console.WriteLine($"-----------------------------------------");
            PrintAllDepartments(_departmentService.GetDepartmentsList());
            Console.WriteLine("Please enter name of department you want to move the student to: ");
            string departmentName = Console.ReadLine();
            var department = _departmentService.GetDepartmentByName(departmentName);
            _studentService.CreateStudentAndAddtoDepartmentWithClasses(name, lastname, department);
            Console.WriteLine($"-----------------------------------------");
            PrintAllStudents(department.Students);
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
            Console.WriteLine($"-----------------------------------------");
            PrintAllStudents(_studentService.GetStudentsList());
            Console.WriteLine("Please select student which you want to move: ");
            Console.WriteLine("By writing the ID");
            int studentId = 0;
            try
            {
                studentId = int.Parse(Console.ReadLine());
                while (studentId > _studentService.GetStudentsList().Count)
                {
                    Console.WriteLine("Seems like you enter a non existant Id. Try again: ");
                    studentId = int.Parse(Console.ReadLine());
                }
            }
            catch { Console.WriteLine("Seems like the inputs id is invalid"); }
            var student = _studentService.GetStudentById(studentId);
            Console.WriteLine($"Selected student: [{student.Id}] {student.Name} {student.LastName}");

            Console.WriteLine($"-----------------------------------------");
            PrintAllDepartments(_departmentService.GetDepartmentsList());
            Console.WriteLine("Please select department to which you want to move the student: ");
            Console.WriteLine("By writing the ID");
            int departmentId = 0;
            try
            {
                departmentId = int.Parse(Console.ReadLine());
                while (departmentId > _departmentService.GetDepartmentsList().Count)
                {
                    Console.WriteLine("Seems like you enter a non existant Id. Try again: ");
                    departmentId = int.Parse(Console.ReadLine());
                }
            }
            catch { Console.WriteLine("Seems like the inputs id is invalid"); }
            var department = _departmentService.GetDepartmentById(departmentId);
            Console.WriteLine($"Selected department: [{department.Id}] {department.Name}");
            _studentService.AddOneStudentToDepartment(student, department);
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
                PrintAllClasses(student.DepartmentOfStudent.Classes);
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
                var departmentName = Console.ReadLine();
                var department = _departmentService.GetDepartmentByName(departmentName);
                PrintAllStudents(department.Students);
            }
            catch { Console.WriteLine("This department is not valid or does not exist"); }
        }
        public void PrintAllStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"[{student.Id}] {student.Name} {student.LastName} Department: {student.DepartmentOfStudent.Name}");
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
