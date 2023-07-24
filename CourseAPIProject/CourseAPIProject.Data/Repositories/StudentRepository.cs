using CourseAPIProject.Core.Repositories;
using CourseAPIProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(CourseDBContext context) : base(context)
        {
        }
    }
}
