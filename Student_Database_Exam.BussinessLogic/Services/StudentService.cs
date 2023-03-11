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
        public void AddStudentsToDepartment(List<Student> students, Department department)
        {
            foreach (var student in students)
            {
                _departmentService.DeleteStudentFromDepartment(department, student);
                student.Classes = department.Classes;
                student.DepartmentOfStudent = department;
                _studentsRepo.AddStudent(student);
            }
        }
        public void AddOneStudentToDepartment(Student student, Department department)
        {
            _departmentService.DeleteStudentFromDepartment(department, student);
            student.Classes = department.Classes; 
            student.DepartmentOfStudent = department;
            _studentsRepo.AddStudent(student);
        }

        public void CreateStudentAndAddtoDepartmentWithClasses(string name, string lastName, Department department)
        {
            var student = new Student(name, lastName, new List<Class>(), department);
            AddOneStudentToDepartment(student, department);
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

        public List<Student> GetStudentsList()
        {
            return _studentsRepo.GetStudentsList();
        }
    }
}
