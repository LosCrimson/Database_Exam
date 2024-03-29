﻿using Student_Database_Exam.Repository.Models;

namespace Student_Database_Exam.Repository.Interfaces
{
    public interface IClassesRepo
    {
        Class GetClassById(int id);
        Class GetClassByName(string name);
        List<Department> GetDepartmentsOfAClass(Class classVar);
        void AddClass(Class classVar);
        List<Class> GetClassesList();
    }
}
