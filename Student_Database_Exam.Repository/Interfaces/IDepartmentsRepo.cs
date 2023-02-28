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
        List<Student> GetDeparmentStudents(Department department);
        List<Class> GetDepartmentClasses(Department department);
        void AddDepartment(Department department);
    }
}
