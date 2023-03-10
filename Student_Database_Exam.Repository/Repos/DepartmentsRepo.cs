using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Student_Database_Exam.Repository.Interfaces;
using Student_Database_Exam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.Repository.Repos
{
    public class DepartmentsRepo : IDepartmentsRepo
    {
        private readonly Student_Database_ExamDbContext _dbContext;

        public DepartmentsRepo(Student_Database_ExamDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       public void AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
        }
        public void DeleteStudentFromDepartment(Department department, Student studentToDelete)
        {
            foreach(var student in department.Students) 
            {
                if (studentToDelete == student)
                {
                    _dbContext.Remove(student);
                }
            }
        }

        public List<Class> GetClassesOfADepartment(Department department)
        {
            return department.Classes;
        }

        public Department GetDepartmentById(int id)
        {
            return _dbContext.Departments.Where<Department>(x => x.Id == id).FirstOrDefault();
        }

        public Department GetDepartmentByName(string name)
        {
            return _dbContext.Departments.Where<Department>(x => x.Name == name).FirstOrDefault();
        }

        public List<Student> GetStudentsOfADepartment(Department department)
        {
            return department.Students;
        }
        public List<Department> GetDepartmentsList()
        {
            List<Department> list = new List<Department>();
            return list = _dbContext.Departments.ToList();
        }
    }
}
