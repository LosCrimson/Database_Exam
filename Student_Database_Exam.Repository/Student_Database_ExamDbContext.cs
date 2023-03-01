﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Database_Exam.Repository.Models;


namespace Student_Database_Exam.Repository
{
    public class Student_Database_ExamDbContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public Student_Database_ExamDbContext(DbContextOptions<Student_Database_ExamDbContext> options) : base(options)
        {

        }

    }
}
