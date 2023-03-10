using Student_Database_Exam.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Database_Exam.Repository.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            List<Class> list = new List<Class>();
            return list = _dbContext.Classes.ToList();
        }
    }
}
