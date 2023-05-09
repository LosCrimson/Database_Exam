using System.ComponentModel.DataAnnotations;

namespace Student_Database_Exam.Repository.Models
{
    public class Department
    {
        [Key] // specify Id as the primary key
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
        public Department() { }
    }
}
