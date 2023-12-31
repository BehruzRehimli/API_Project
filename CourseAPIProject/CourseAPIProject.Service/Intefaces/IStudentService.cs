﻿using CourseAPIProject.Service.Dtos.Common;
using CourseAPIProject.Service.Dtos.Group;
using CourseAPIProject.Service.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Intefaces
{
    public interface IStudentService
    {
        CreateResultDto Create(StudentCreateDto dto);
        void Delete(int id);
        StudentGetDto GetById(int id);
        List<StudentGetAllDto> GetAll();
        void Edit(int id, StudentEditDto dto);

    }
}
