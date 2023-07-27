using CourseAPIProject.Service.Dtos.Common;
using CourseAPIProject.Service.Dtos.Group;
using CourseAPIProject.Service.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPIProject.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpPost("")]
        public ActionResult<CreateResultDto> Create(GroupCreateDto dto)
        {
            return _groupService.Create(dto);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _groupService.Delete(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<GroupGetDto> Get(int id)
        {
            return _groupService.GetById(id);
        }
        [HttpGet("")]
        public ActionResult<List<GroupGetAllDto>> Get()
        {
            return _groupService.GetAll();
        }
        [HttpPut("{id}")]
        public ActionResult Edit(int id,GroupEditDto dto)
        {
            _groupService.Edit(id, dto);
            return NoContent();
        }
    }
}
