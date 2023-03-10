using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Database_Exam.Repository.Models;

namespace Student_Database_Exam.Repository.Interfaces
{
    public interface IDepartmentsRepo
    {
        Department GetDepartmentById (int id);
        Department GetDepartmentByName (string name);
        List<Student> GetStudentsOfADepartment(Department department);
        List<Class> GetClassesOfADepartment(Department department);
        void AddDepartment(Department department);
        void DeleteStudentFromDepartment(Department department, Student student);
        List<Department> GetDepartmentsList();
    }
}
