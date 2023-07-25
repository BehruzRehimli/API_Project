using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Dtos.Student
{
    public class StudentEditDto
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public decimal Point { get; set; }
        public int GroupId { get; set; }
    }
    public class StudentEditDtoValidator : AbstractValidator<StudentEditDto>
    {
        public StudentEditDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Point).LessThanOrEqualTo(100).GreaterThanOrEqualTo(0);
            RuleFor(x=>x.GroupId).GreaterThan(0);
            RuleFor(x => x.Age).GreaterThan(0);
        }
    }
}
