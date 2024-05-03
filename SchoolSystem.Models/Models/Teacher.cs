using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.Models
{
    public  class Teacher:BaseEntity
    {
        public Subject Subject { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public List<Student> Students { get; set; }
        public List<CourseTeacherRelation> CourseTeacherRelations { get; set; } 

    }
}
