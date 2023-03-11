using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.BussinessLogic.Interfaces
{
    public interface IDatabaseManagmentService
    {
        void CreateDepartmentsForTesting();
        void CreateClassesForTesting();
        void CreateStudentsForTesting();
        void AskUserToCreateTestingDatabase();
        void AsKUserAboutDbSettings();

    }
}
