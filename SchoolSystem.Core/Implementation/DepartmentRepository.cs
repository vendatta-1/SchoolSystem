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
    public class DepartmentRepository:BaseRepository<Department>,IDepartmentRepository
    {
        private readonly SchoolDbContext _context;
        private readonly ILogger<BaseRepository<Department>> _logger; 

        public DepartmentRepository(SchoolDbContext context,ILogger<BaseRepository<Department>> departmentLog ):base(context,departmentLog)
        {
            _context = context;
            _logger = departmentLog;
        }
        public override Task<IEnumerable<Department>> GetAll(params string[]? includes)
        {

            return base.GetAll(includes);
        }
    }
}
