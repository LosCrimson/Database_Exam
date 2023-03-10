using Student_Database_Exam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.BussinessLogic.Interfaces
{
    public interface IDepartmentService
    {
        void CreateDepartment(string name);
        Department GetDepartmentById(int id);
        Department GetDepartmentByName(string name);
        void DeleteStudentFromDepartment(Department department, Student student);
        List<Student> GetAllStudentdsInDepartment(Department department);
        List<Department> GetDepartmentsList();
    }
}
