using SchoolSystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models.Models;

namespace SchoolSystem.Core.Initialize
{
    public static class SchoolDbInitializer
    {
        public static void Initialize(SchoolDbContext context) 
        {
            if(context == null) throw new ArgumentNullException("context");
            context.Database.EnsureCreated();
            if(!context.Schools.Any()) 
            {
                List<School> schools = new List<School>()
                {
                    new School() {Name="School one"},
                    new School() {Name="School Two"}
                };
                context.AddRange(schools);
                context.SaveChanges();
            }
            if (!context.Students.Any())
            {
                List<Student> students = new List<Student>()
                {
                    new Student()
                    {
                        
                    }
                };
            }
        }
    }
}
