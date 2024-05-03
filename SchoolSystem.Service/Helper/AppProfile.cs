using AutoMapper;
using SchoolSystem.Models.Models;
using SchoolSystem.Service.Dto;
using SchoolSystem.Service.Dto.Department;

namespace SchoolSystem.Service.Helper
{
    public class AppProfile :Profile
    {
        public AppProfile()
        {
            CreateMap<Department, DepartmentBaseDto>().ReverseMap();
            CreateMap<Department,DepartmentCreateDto>().ReverseMap();
            
        }
    }
}
