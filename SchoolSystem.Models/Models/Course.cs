using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.Models
{
    public class Course:BaseEntity
    {

        public List<CourseTeacherRelation> CourseTeacherRelations { get; set; } // Represents the association between Course and Teacher

        public List<Student> Students { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
