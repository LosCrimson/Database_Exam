using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.Repository.Models
{
    public class Class
    {
        public int Id { get; set; }
        public List<Department> Departments { get; set; }
        public Class(List<Department> departments) 
        {
            Departments = departments;
        }
    }
}
