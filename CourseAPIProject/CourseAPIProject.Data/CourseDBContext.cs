using CourseAPIProject.Data.Configurations;
using CourseAPIProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Data
{
    public class CourseDBContext:DbContext
    {
        public CourseDBContext(DbContextOptions<CourseDBContext> opt):base(opt) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
            base.OnModelCreating(modelBuilder); 
        }
    }
}
