using Student_Database_Exam.BussinessLogic.Interfaces;
using Student_Database_Exam.Repository;
using Student_Database_Exam.Repository.Interfaces;
using Student_Database_Exam.Repository.Models;
using Student_Database_Exam.Repository.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.BussinessLogic.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentsRepo _departmentsRepo;
        public DepartmentService(IDepartmentsRepo departmentsRepo)
        {
            _departmentsRepo = departmentsRepo;
        }
        public void CreateDepartment(string name)
        {
            var department = new Department(name);
            _departmentsRepo.AddDepartment(department);
        }

        public void DeleteStudentFromDepartment(Department department,Student student)
        {
            _departmentsRepo.DeleteStudentFromDepartment(department, student);
        }

        public Department GetDepartmentById(int id)
        {
            Department department = _departmentsRepo.GetDepartmentById(id);
            return department;
        }

        public Department GetDepartmentByName(string name)
        {
            Department department = _departmentsRepo.GetDepartmentByName(name);
            return department;
        }
        public List<Student> GetAllStudentdsInDepartment(Department department)
        {
            return _departmentsRepo.GetStudentsOfADepartment(department);
        }
        public List<Department> GetDepartmentsList()
        {
            return _departmentsRepo.GetDepartmentsList();
        }
    }
}
