﻿namespace Student_Database_Exam.Repository.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Department DepartmentOfStudent { get; set; }
        public Student(string name, string lastName, Department departmentOfStudent)
        {
            Name = name;
            LastName = lastName;
            DepartmentOfStudent = departmentOfStudent;
        }
        public Student() { }
    }
}
