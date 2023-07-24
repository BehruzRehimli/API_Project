using CourseAPIProject.Core.Repositories;
using CourseAPIProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(CourseDBContext context) : base(context)
        {
        }
    }
}
