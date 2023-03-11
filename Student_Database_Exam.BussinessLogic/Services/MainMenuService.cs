using Student_Database_Exam.BussinessLogic.Interfaces;
using Student_Database_Exam.Repository.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.BussinessLogic.Services
{
    public class MainMenuService : IMainMenuService
    {
        private readonly IUIService _uiService;
        private readonly IDatabaseManagmentService _databaseManagmentService;
        public MainMenuService(IUIService uiService, IDatabaseManagmentService databaseManagmentService)
        {
            _uiService = uiService;
            _databaseManagmentService = databaseManagmentService;
        }
        public void MainMenu()
        {
            //_databaseManagmentService.AsKUserAboutDbSettings();
            //_databaseManagmentService.AskUserToCreateTestingDatabase();

            while (true)
            {
                switch (_uiService.GetActionType())
                {
                    case ActionTypes.ShowAllStudentsInDepartment:
                        _uiService.ShowAllStudentsInDepartment();
                        break;
                    case ActionTypes.ShowAllClassesInDepartment:
                        _uiService.ShowAllClassesInDepartment();
                        break;
                    case ActionTypes.ShowAllClassesOfStudent:
                        _uiService.ShowAllClassesOfStudent();
                        break;
                    case ActionTypes.CreateDepartment:
                        _uiService.CreateDepartment();
                        break;
                    case ActionTypes.AddStudentsAndOrClassesToDepartment:
                        _uiService.AddStudentsAndOrClassesToDepartment();
                        break;
                    case ActionTypes.CreateClassAndAddToDepartment:
                        _uiService.CreateClassAndAddToDepartment();
                        break;
                    case ActionTypes.CreateStudentAndAddtoDepartmentWithClasses:
                        _uiService.CreateStudentAndAddtoDepartmentWithClasses();
                        break;
                    case ActionTypes.MoveStudentToAnotherDepartment:
                        _uiService.MoveStudentToAnotherDepartment();
                        break;
                    case ActionTypes.EXIT:
                        return;
                }
            }
        }
    }
}
