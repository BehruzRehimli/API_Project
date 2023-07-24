using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Dtos.Group
{
    public class GroupGetDto
    {
        public string Name { get; set; }
        public int MaxStudentCount { get; set; }
        public int StudentsCount { get; set; }
    }
}
