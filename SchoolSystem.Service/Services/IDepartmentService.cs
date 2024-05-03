using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolSystem.Core.Contract;
using SchoolSystem.Core.Repos;
using SchoolSystem.Models.Models;
using SchoolSystem.Service.Dto.Department;

namespace SchoolSystem.Service.Services;

public interface IDepartmentService :IBaseServices<Department,DepartmentBaseDto> 
{
    
}
public class DepartmentService :BaseServices<Department,DepartmentBaseDto>,IDepartmentService 
{
    private IDepartmentRepository _repository;
    private IMapper _mapper;
    private ILogger<DepartmentService> _logger; 
    public DepartmentService(IDepartmentRepository repository, IMapper mapper ,ILogger<DepartmentService> logger) : base(repository, mapper,logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }


}