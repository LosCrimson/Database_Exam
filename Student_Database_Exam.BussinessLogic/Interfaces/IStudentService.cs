using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Database_Exam.Repository.Models;

namespace Student_Database_Exam.BussinessLogic.Interfaces
{
    public interface IStudentService
    {
        void AddStudentsToDepartment(List<Student> students, Department department);
        void CreateStudentAndAddtoDepartmentWithClasses(string name, string lastName, Department department);
        void MoveStudentToAnotherDepartment(Student student, Department department);
        Student GetStudentById(int id);
        Student GetStudentByName(string name);
        Student GetStudentByLastName(string lastName);
        List<Student> GetStudentsByDepartment(Department department);
        void AddOneStudentToDepartment(Student students);
        List<Student> GetStudentsList();
    }
}
