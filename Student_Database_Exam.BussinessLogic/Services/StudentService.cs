using Student_Database_Exam.BussinessLogic.Interfaces;
using Student_Database_Exam.Repository;
using Student_Database_Exam.Repository.Interfaces;
using Student_Database_Exam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void AddStudentsToDepartment(List<Student> students)
        {
            foreach (var student in students)
            {
                var departmentAndStudentClassesMerged = student.Classes.Union(_departmentService.GetDepartmentById(student.DepartmentOfStudent.Id).Classes).ToList();
                student.Classes = departmentAndStudentClassesMerged;
                _studentsRepo.AddStudent(student);
            }
        }
        public void AddOneStudentToDepartment(Student student)
        {
                var departmentAndStudentClassesMerged = student.Classes.Union(_departmentService.GetDepartmentById(student.DepartmentOfStudent.Id).Classes).ToList();
                student.Classes = departmentAndStudentClassesMerged;
                _studentsRepo.AddStudent(student);
        }

        public void CreateStudentAndAddtoDepartmentWithClasses(string name, string lastName, Department department)
        {
            var student = new Student(name, lastName, new List<Class>(), department);
            AddOneStudentToDepartment(student);
        }

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

        public void MoveStudentToAnotherDepartment(Student student, Department department)
        {
            _departmentService.DeleteStudentFromDepartment(department, student);
            student.Classes = new List<Class>();
            student.DepartmentOfStudent = department;
            AddOneStudentToDepartment(student);
        }
        public List<Student> GetStudentsList()
        {
            return _studentsRepo.GetStudentsList();
        }
    }
}
