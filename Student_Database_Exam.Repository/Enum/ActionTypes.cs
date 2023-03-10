using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.Repository.Enum
{
    public enum ActionTypes
    {
        ShowAllStudentsInDepartment,
        ShowAllClassesInDepartment,
        ShowAllClassesOfStudent,
        CreateDepartment,
        AddStudentsAndOrClassesToDepartment,
        CreateClassAndAddToDepartment,
        CreateStudentAndAddtoDepartmentWithClasses,
        MoveStudentToAnotherDepartment,
        EXIT
    }
}
