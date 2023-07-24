using AutoMapper;
using CourseAPIProject.Core.Repositories;
using CourseAPIProject.Data.Entities;
using CourseAPIProject.Service.Dtos.Common;
using CourseAPIProject.Service.Dtos.Group;
using CourseAPIProject.Service.Exceptions;
using CourseAPIProject.Service.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Implemantations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupService, IMapper mapper)
        {
            _groupRepository = groupService;
            _mapper = mapper;
        }

        public CreateResultDto Create(GroupCreateDto dto)
        {
            if (_groupRepository.IsExsist(x=>x.Name==dto.Name))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", $"Name already exsists {dto.Name}");
            }
            Group group=_mapper.Map<Group>(dto);
            _groupRepository.Add(group);
            _groupRepository.Commit();
            return _mapper.Map<CreateResultDto>(group);
        }

        public void Delete(int id)
        {
            if (!_groupRepository.IsExsist(x=>x.Id==id))
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Group can't find {id} id!");
            }
            _groupRepository.Remove(_groupRepository.Find(x => x.Id == id));
            _groupRepository.Commit();
        }

        public List<GroupGetAllDto> GetAll()
        {
            List<Group> groups = _groupRepository.Get(x => true, "Students").ToList();
            return _mapper.Map<List<GroupGetAllDto>>(groups);
        }

        public GroupGetDto GetById(int id)
        {
            if (!_groupRepository.IsExsist(x => x.Id == id))
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Group can't find {id} id!");
            }
            Group group = _groupRepository.Find(x => x.Id == id, "Students");
            return _mapper.Map<GroupGetDto>(group);
        }

    }
}
