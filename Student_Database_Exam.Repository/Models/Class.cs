﻿namespace Student_Database_Exam.Repository.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public Class(string name, List<Department> departments)
        {
            Name = name;
            Departments = departments;
        }
        public Class() { }
    }
}
