using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.Models
{
    public class Grade
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudnetId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public double Value { get; set; }
    }
}
