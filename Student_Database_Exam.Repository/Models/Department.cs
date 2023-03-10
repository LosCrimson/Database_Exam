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
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Class> Classes { get; set; }

        public Department(string name, List<Student> students, List<Class> classes)
        {
            Name = name;
            Students = students;
            Classes = classes;
        }
        public Department(string name)
        {
            Name = name;
            Students = new List<Student>();
            Classes = new List<Class>();
        }
    }
}
