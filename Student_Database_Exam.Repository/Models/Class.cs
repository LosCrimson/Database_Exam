using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.Repository.Models
{
    public class Class
    {
        public int Id { get; set; }

        [Key] // specify Name as the primary key
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
