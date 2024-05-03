using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.Models
{
    public class ExamGrade
    {
        [Key]
        public int ExamGradeId { get; set; }
        public Exam Exam { get; set; }
        public Student Student { get; set; }
        public double Grade { get; set; }
    }
}
