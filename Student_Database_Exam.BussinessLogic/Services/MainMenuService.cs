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
        public MainMenuService(IUIService uiService)
        {
            _uiService = uiService;
        }
        public void MainMenu()
        {

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

                        break;
                    case ActionTypes.CreateClassAndAddToDepartment:

                        break;
                    case ActionTypes.CreateStudentAndAddtoDepartmentWithClasses:

                        break;
                    case ActionTypes.MoveStudentToAnotherDepartment:

                        break;
                    case ActionTypes.EXIT:
                        return;
                }
            }
        }
    }
}
