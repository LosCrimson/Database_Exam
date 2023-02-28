using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Database_Exam.Repository.Models
{
    public class Department
    {
        public int Id { get; set; }
        public List<Student> Students { get; set; }
        public List<Class> Classes { get; set; }

        public Department(List<Student> students, List<Class> classes)
        {
            Students = students;
            Classes = classes;
        }
    }
}
