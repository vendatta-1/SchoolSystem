using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Core.Repos;
using SchoolSystem.Models.Models;
using SchoolSystem.Service.Dto;
using SchoolSystem.Service.Dto.Department;
using SchoolSystem.Service.Services;

namespace SchoolSystem.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _departmentService.GetAll("Teachers");
            if (result == null)
                return BadRequest("there is non element exist in this entity");
            return Ok(result);
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> Get(int id)
        {
            var result=await _departmentService.GetByIdAsync(id);
            if(result is not null)
                return Ok(result);
            return BadRequest(nameof(result));
        }
        [HttpPost]
        public async Task< IActionResult> Create([FromBody] DepartmentCreateDto dept)
        {
            if (!ModelState.IsValid)
                return BadRequest("the model is not valid");
            var result=await _departmentService.CreateAsync(dept);
            return Ok(result);  
        }
    }
}
