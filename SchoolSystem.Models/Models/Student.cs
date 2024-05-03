using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.Models
{
    public class Student:BaseEntity
    {
        public DateTime DateOfBirth { get; set; }
        public List<Course> Courses { get; set; }
        public List<Grade> Grades { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        public Teacher Advisor { get; set; }
    }
}
