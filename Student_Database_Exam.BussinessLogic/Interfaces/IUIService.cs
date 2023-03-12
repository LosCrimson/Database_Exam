using Student_Database_Exam.Repository.Enum;
using Student_Database_Exam.Repository.Models;

namespace Student_Database_Exam.BussinessLogic.Interfaces
{
    public interface IUIService
    {
        void ShowAllStudentsInDepartment();
        void ShowAllClassesInDepartment();
        void ShowAllClassesOfStudent();
        void CreateDepartment();
        void AddStudentsAndOrClassesToDepartment();
        void CreateClassAndAddToDepartment();
        void CreateStudentAndAddtoDepartmentWithClasses();
        void MoveStudentToAnotherDepartment();
        ActionTypes GetActionType();
        void PrintAllClasses(List<Class> classes);
        void PrintAllDepartments(List<Department> departments);
        void PrintAllStudents(List<Student> students);
    }
}
