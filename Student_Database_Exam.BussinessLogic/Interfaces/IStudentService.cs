using Student_Database_Exam.Repository.Models;

namespace Student_Database_Exam.BussinessLogic.Interfaces
{
    public interface IStudentService
    {
        void AddStudentsToDepartment(List<Student> students, Department department);
        void CreateStudentAndAddtoDepartmentWithClasses(string name, string lastName, Department department);
        Student GetStudentById(int id);
        Student GetStudentByName(string name);
        Student GetStudentByLastName(string lastName);
        List<Student> GetStudentsByDepartment(Department department);
        void AddOneStudentToDepartment(Student students, Department department);
        List<Student> GetStudentsList();
        void CreateStudentAndAddtoDepartmentWithClassesButDoNotDelete(string name, string lastName, Department department);
        void AddOneStudentToDepartmentButNoDeleation(Student student, Department department);
    }
}
