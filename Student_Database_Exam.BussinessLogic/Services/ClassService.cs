using Student_Database_Exam.BussinessLogic.Interfaces;
using Student_Database_Exam.Repository.Interfaces;
using Student_Database_Exam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.BussinessLogic.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassesRepo _classesRepo;
        public ClassService(IClassesRepo classesRepo)
        {
            _classesRepo = classesRepo;
        }
        public void AddClassessToDepartment(List<string> names, List<Department> departments)
        {
            var classes = new List<Class>();
            foreach (string name in names) 
            {
                classes.Add(new Class(name, departments));
            }
            foreach (var newClass in classes)
            {
                _classesRepo.AddClass(newClass);
            }
        }

        public void CreateClassAndAddToDepartment(string name, List<Department> departments)
        {
            var newClass = new Class(name, departments);
            _classesRepo.AddClass(newClass);
        }

        public Class GetClassById(int id)
        {
            Class getClass = _classesRepo.GetClassById(id);
            return getClass;
        }

        public Class GetClassByName(string name)
        {
            Class getClass = _classesRepo.GetClassByName(name);
            return getClass;
        }
        public List<Class> GetClassesList()
        {
           return _classesRepo.GetClassesList();
        }
    }
}
