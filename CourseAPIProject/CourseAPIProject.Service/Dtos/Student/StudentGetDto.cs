using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Dtos.Student
{
    public class StudentGetDto
    {
        public string FullName { get; set; }
        public decimal Point { get; set; }
        public byte Age { get; set; }
        public StudentGetGroup Group { get; set; }
    }
    public class StudentGetGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentsCount { get; set; }
    }
}
