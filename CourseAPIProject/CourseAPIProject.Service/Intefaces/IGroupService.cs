using CourseAPIProject.Service.Dtos.Common;
using CourseAPIProject.Service.Dtos.Group;
using CourseAPIProject.Service.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Intefaces
{
    public interface IGroupService
    {
        CreateResultDto Create(GroupCreateDto dto);
        void Delete(int id);
        GroupGetDto GetById(int id);
        List<GroupGetAllDto> GetAll();
        void Edit(int id, GroupEditDto dto);
    }
}
