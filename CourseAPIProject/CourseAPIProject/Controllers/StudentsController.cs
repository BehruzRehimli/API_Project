using CourseAPIProject.Service.Dtos.Common;
using CourseAPIProject.Service.Dtos.Student;
using CourseAPIProject.Service.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPIProject.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("")]
        public ActionResult<CreateResultDto> Create(StudentCreateDto dto)
        {
            return _studentService.Create(dto);
        }
        [HttpGet("{id}")]
        public ActionResult<StudentGetDto> Get(int id)
        {
            return _studentService.GetById(id);
        }
        [HttpGet("")]
        public ActionResult<List<StudentGetAllDto>> Get()
        {
            return _studentService.GetAll();
        }
        [HttpPut("{id}")]
        public ActionResult Edit(int id,StudentEditDto dto)
        {
            _studentService.Edit(id, dto);
            return NoContent();
        }
        [HttpDelete("id")]
        public ActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return NoContent();
        }

    }
}
