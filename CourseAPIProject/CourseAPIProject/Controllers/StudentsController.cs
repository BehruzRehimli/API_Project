using CourseAPIProject.Service.Dtos.Common;
using CourseAPIProject.Service.Dtos.Student;
using CourseAPIProject.Service.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPIProject.Controllers
{
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
    }
}
