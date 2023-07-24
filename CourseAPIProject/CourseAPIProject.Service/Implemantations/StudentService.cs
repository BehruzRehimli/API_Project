using AutoMapper;
using CourseAPIProject.Core.Repositories;
using CourseAPIProject.Data.Entities;
using CourseAPIProject.Data.Repositories;
using CourseAPIProject.Service.Dtos.Common;
using CourseAPIProject.Service.Dtos.Student;
using CourseAPIProject.Service.Exceptions;
using CourseAPIProject.Service.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Implemantations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper, IGroupRepository groupRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _groupRepository = groupRepository;
        }
        public CreateResultDto Create(StudentCreateDto dto)
        {
            if (!_groupRepository.IsExsist(x=>x.Id==dto.GroupId))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "GroupId", $"There is no Group in {dto.GroupId} id!");
            }
            Student student = _mapper.Map<Student>(dto);
            _studentRepository.Add(student);
            _studentRepository.Commit();
            return _mapper.Map<CreateResultDto>(student);
        }
    }
}
