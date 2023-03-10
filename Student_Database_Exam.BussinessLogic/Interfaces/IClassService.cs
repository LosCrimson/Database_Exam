using Student_Database_Exam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.BussinessLogic.Interfaces
{
    public interface IClassService
    {
        void AddClassessToDepartment(List<Class> classList, Department department);
        void CreateClassAndAddToDepartment(string name, List<Department> department);
        Class GetClassById(int id);
        Class GetClassByName(string name);
        List<Class> GetClassesList();
    }
}
