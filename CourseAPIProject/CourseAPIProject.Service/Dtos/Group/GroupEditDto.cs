using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Dtos.Group
{
    public class GroupEditDto
    {
        public string Name { get; set; }
        public int MaxStudentCount { get; set; }
    }
    public class GroupEditDtoValidator : AbstractValidator<GroupEditDto>
    {
        public GroupEditDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(10);
            RuleFor(x=>x.MaxStudentCount).GreaterThan(0);
        }
    }
}
