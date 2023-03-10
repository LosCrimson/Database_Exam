using Student_Database_Exam.BussinessLogic.Interfaces;
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
    public class ClassService : IClassService
    {
        private readonly IClassesRepo _classesRepo;
        private readonly IDepartmentService _departmentService;
        public ClassService(IClassesRepo classesRepo, IDepartmentService departmentService)
        {
            _classesRepo = classesRepo;
            _departmentService = departmentService;
        }
        public void AddClassessToDepartment(List<Class> classList, Department department)
        {
            foreach (var classItem in classList)
            {
                classItem.Departments.Add(department);
                _classesRepo.AddClass(classItem);
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
