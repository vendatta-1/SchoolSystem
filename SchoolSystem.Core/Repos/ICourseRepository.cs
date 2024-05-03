using SchoolSystem.Core.Contract;
using SchoolSystem.Core.Implementation;
using SchoolSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Repos
{
    public interface ICourseRepository:IBaseRepository<Course>
    {
    }
}
