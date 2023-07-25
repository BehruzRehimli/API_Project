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

        public void Delete(int id)
        {
            if (!_studentRepository.IsExsist(x=>x.Id==id))
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"There is no Student in {id} id!");
            }
            Student student=_studentRepository.Find(x=>x.Id==id);
            _studentRepository.Remove(student);
            _studentRepository.Commit();
        }

        public void Edit(int id, StudentEditDto dto)
        {
            if (!_studentRepository.IsExsist(x => x.Id == id))
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"There is no Student in {id} id!");
            }
            Student student = _studentRepository.Find(x => x.Id == id, "Group");
            if (student.GroupId!=dto.GroupId && !_groupRepository.IsExsist(x=>x.Id==dto.GroupId))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, $"There is no Group in {dto.GroupId} id!");
            }
            student.FullName= dto.FullName;
            student.Age= dto.Age;
            student.Point=dto.Point;
            student.GroupId= dto.GroupId;
            _studentRepository.Commit();
        }

        public List<StudentGetAllDto> GetAll()
        {
            List<Student> students=_studentRepository.Get(x=>true,"Group").ToList();
            return _mapper.Map<List<StudentGetAllDto>>(students);
        }

        public StudentGetDto GetById(int id)
        {
            if (!_studentRepository.IsExsist(x => x.Id == id))
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"There is no Student in {id} id!");
            }
            Student student = _studentRepository.Find(x => x.Id == id, "Group");
            return _mapper.Map<StudentGetDto>(student);

        }
    }
}
