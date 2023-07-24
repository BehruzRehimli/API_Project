
using CourseAPIProject.Core.Repositories;
using CourseAPIProject.Data;
using CourseAPIProject.Data.Repositories;
using CourseAPIProject.Middlewares;
using CourseAPIProject.Service.Dtos.Student;
using CourseAPIProject.Service.Exceptions;
using CourseAPIProject.Service.Implemantations;
using CourseAPIProject.Service.Intefaces;
using CourseAPIProject.Service.Profiles;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Where(x => x.Value?.Errors.Count() > 0)
            .Select(x => new RestExceptionItem(x.Key, x.Value?.Errors.First().ErrorMessage)).ToList();

        return new BadRequestObjectResult(new { message = (string)null, errors = errors });

    };
});
builder.Services.AddDbContext<CourseDBContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddValidatorsFromAssemblyContaining<StudentCreateValidator>();

builder.Services.AddScoped<IGroupRepository,GroupRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IGroupService, GroupService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();
