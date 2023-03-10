﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Database_Exam.Repository.Models;
using Student_Database_Exam.Repository.Enum;

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
