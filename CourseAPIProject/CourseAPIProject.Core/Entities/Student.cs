using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public decimal Point { get; set; }
        public Group Group { get; set; }
    }
}
