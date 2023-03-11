using Microsoft.EntityFrameworkCore;
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
    public class StudentsRepo : IStudentsRepo
    {
        private readonly Student_Database_ExamDbContext _dbContext;
        public StudentsRepo(Student_Database_ExamDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public List<Class> GetClassesOfAStudent(Student student)
        {
            return student.Classes;
        }

        public Department GetDepartmentOfAStudent(Student student)
        {
            return student.DepartmentOfStudent;
        }

        public Student GetStudentById(int id)
        {
            return _dbContext.Students.Where<Student>(x => x.Id == id).FirstOrDefault();
        }

        public Student GetStudentByName(string name)
        {
            return _dbContext.Students.Where<Student>(x => x.Name == name).FirstOrDefault();
        }
        public Student GetStudentByLastName(string name)
        {
            return _dbContext.Students.Where<Student>(x => x.LastName == name).FirstOrDefault();
        }
        public List<Student> GetStudentsList()
        {
            return _dbContext.Students.ToList();
        }
    }
}
