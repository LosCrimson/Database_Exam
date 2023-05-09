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
