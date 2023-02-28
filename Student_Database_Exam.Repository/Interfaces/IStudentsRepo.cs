using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Database_Exam.Repository.Models;

namespace Student_Database_Exam.Repository.Interfaces
{
    public interface IStudentsRepo
    {
        Student GetStudentById (int id);
        List<Class> GetStudentClasses(Student student);
        Department GetStudentDepartment (Student student);
        void AddStudent(Student student);
    }
}
