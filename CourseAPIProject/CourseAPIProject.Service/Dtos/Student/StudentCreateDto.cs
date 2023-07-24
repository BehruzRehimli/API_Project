using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Dtos.Student
{
    public class StudentCreateDto
    {
        public string FullName { get; set; }
        public decimal Point { get; set; }
        public byte Age { get; set; }
        public int GroupId { get; set; }
    }
    public class StudentCreateValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateValidator()
        {
            RuleFor(x => x.FullName).NotNull().MaximumLength(100);
            RuleFor(x => x.Point).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
            RuleFor(x => x.GroupId).GreaterThan(0);
        }
    }
}
