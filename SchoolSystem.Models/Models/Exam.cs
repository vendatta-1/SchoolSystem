using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        public Course Course { get; set; }
        public DateTime Date { get; set; }
        public List<Student> Students { get; set; }
        public List<ExamGrade> ExamGrades { get; set; } 
        public List<Teacher> ConductedBy { get; set; }
    }
}
