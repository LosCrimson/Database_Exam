using Student_Database_Exam.BussinessLogic.Interfaces;
using Student_Database_Exam.Repository.Interfaces;
using Student_Database_Exam.Repository.Models;

namespace Student_Database_Exam.BussinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentsRepo _studentsRepo;
        private readonly IDepartmentService _departmentService;
        public StudentService(IStudentsRepo studentsRepo, IDepartmentService departmentService)
        {
            _studentsRepo = studentsRepo;
            _departmentService = departmentService;
        }
        public void AddStudentsToDepartment(List<Student> students, Department department)
        {
            foreach (var student in students)
            {
                _departmentService.DeleteStudentFromDepartment(department, student);
                student.DepartmentOfStudent.Classes = department.Classes;
                student.DepartmentOfStudent = department;
                _studentsRepo.AddStudent(student);
            }
        }
        public void AddOneStudentToDepartment(Student student, Department department)
        {
            try
            {
                _departmentService.DeleteStudentFromDepartment(department, student);
            }
            catch { Console.WriteLine("Seems like department has no students"); }
            try
            { student.DepartmentOfStudent.Classes = department.Classes; }
            catch { Console.WriteLine("Seems like department has no classes and Student has no classes"); }
            student.DepartmentOfStudent = department;
            _studentsRepo.AddStudent(student);
        }

        public void CreateStudentAndAddtoDepartmentWithClasses(string name, string lastName, Department department)
        {
            var student = new Student(name, lastName, department);
            AddOneStudentToDepartmentButNoDeleation(student, department);
        }

        //Is needed for initial creation--------------------------------------------------------------------------------------------
        public void AddOneStudentToDepartmentButNoDeleation(Student student, Department department)
        {
            student.DepartmentOfStudent.Classes = department.Classes;
            student.DepartmentOfStudent = department;
            _studentsRepo.AddStudent(student);
        }

        public void CreateStudentAndAddtoDepartmentWithClassesButDoNotDelete(string name, string lastName, Department department)
        {
            var student = new Student(name, lastName, department);
            AddOneStudentToDepartmentButNoDeleation(student, department);
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public Student GetStudentById(int id)
        {
            Student student = _studentsRepo.GetStudentById(id);
            return student;
        }

        public Student GetStudentByLastName(string lastName)
        {
            Student student = _studentsRepo.GetStudentByLastName(lastName);
            return student;
        }

        public Student GetStudentByName(string name)
        {
            Student student = _studentsRepo.GetStudentByName(name);
            return student;
        }

        public List<Student> GetStudentsByDepartment(Department department)
        {
            return department.Students;
        }

        public List<Student> GetStudentsList()
        {
            return _studentsRepo.GetStudentsList();
        }
    }
}
