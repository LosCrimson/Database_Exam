using Microsoft.EntityFrameworkCore;
using Student_Database_Exam.Repository.Interfaces;
using Student_Database_Exam.Repository.Models;

namespace Student_Database_Exam.Repository.Repos
{
    public class ClassesRepo : IClassesRepo
    {
        private readonly Student_Database_ExamDbContext _dbContext;

        public ClassesRepo(Student_Database_ExamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Class GetClassById(int id)
        {
            return _dbContext.Classes.Where<Class>(x => x.Id == id).FirstOrDefault();
        }
        public Class GetClassByName(string className)
        {
            return _dbContext.Classes.Where<Class>(x => x.Name == className).FirstOrDefault();
        }
        public List<Department> GetDepartmentsOfAClass(Class classVar)
        {
            return classVar.Departments;
        }
        public void AddClass(Class classVar)
        {
            _dbContext.Classes.Add(classVar);
            _dbContext.SaveChanges();
        }

        public List<Class> GetClassesList()
        {
            return _dbContext.Classes.Include(x => x.Departments).ToList();
        }
    }
}
