using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Data.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxStudentCount { get; set; }
        public List<Student> Students { get; set; }
    }
}
