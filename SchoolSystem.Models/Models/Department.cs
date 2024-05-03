using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.Models
{
    public class Department:BaseEntity
    {
        public Department()
        {
            Teachers = new List<Teacher>();
        }
        public List<Teacher> Teachers { get; set; }
    }
}
