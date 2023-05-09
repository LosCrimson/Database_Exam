using Student_Database_Exam.Repository.Models;

namespace Student_Database_Exam.Repository.Interfaces
{
    public interface IStudentsRepo
    {
        Student GetStudentById(int id);
        Student GetStudentByName(string name);
        Student GetStudentByLastName(string name);
        List<Class> GetClassesOfAStudent(Student student);
        Department GetDepartmentOfAStudent(Student student);
        void AddStudent(Student student);
        List<Student> GetStudentsList();
    }
}
