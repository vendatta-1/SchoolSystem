using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.Models
{
    public class Parent:BaseEntity
    {
        public List<Student> Children { get; set; }
    }
}
