using SchoolSystem.Core.Contract;
using SchoolSystem.Core.Data;
using SchoolSystem.Core.Repos;
using SchoolSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SchoolSystem.Core.Implementation
{
    public class CourseRepository:BaseRepository<Course>,ICourseRepository
    {
        private readonly SchoolDbContext _context;
        private readonly ILogger<BaseRepository<Course>> _logger;
        public CourseRepository(SchoolDbContext context ,ILogger<BaseRepository<Course>> logger):base(context,logger) { _context = context;
            _logger = logger;
        }
      
    }
}
