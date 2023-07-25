using AutoMapper;
using CourseAPIProject.Data.Entities;
using CourseAPIProject.Service.Dtos.Common;
using CourseAPIProject.Service.Dtos.Group;
using CourseAPIProject.Service.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Group,StudentGetGroup>();
            CreateMap<Student, StudentGetDto>();
            CreateMap<Student, StudentGetAllDto>();
            CreateMap<Group,StudentGetAllGroup>();
            CreateMap<Group, StudentGetGroup>();
            CreateMap<GroupCreateDto, Group>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<Group, GroupGetDto>();
            CreateMap<Group, GroupGetAllDto>();


            CreateMap<Student, CreateResultDto>();
            CreateMap<Group, CreateResultDto>();
        }
    }
}
