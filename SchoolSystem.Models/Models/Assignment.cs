using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.Models
{
    public class Assignment:BaseEntity
    {
#pragma warning disable
        public Course Course { get; set; }
        public DateTime DueDate { get; set; }
        public List<Student> SubmittedBy { get; set; }
    }
}
