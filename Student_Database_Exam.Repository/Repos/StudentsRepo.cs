using Microsoft.EntityFrameworkCore;
using Student_Database_Exam.Repository.Interfaces;
using Student_Database_Exam.Repository.Models;

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
            return student.DepartmentOfStudent.Classes;
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
            return _dbContext.Students.Include(x => x.DepartmentOfStudent).Include(x => x.DepartmentOfStudent.Classes).ToList();
        }
    }
}
