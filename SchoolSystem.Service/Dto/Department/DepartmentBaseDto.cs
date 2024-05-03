using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Service.Dto.Department;

public  class  DepartmentBaseDto
{
    public int? Id { get; set; }    
    [StringLength(20)]
    public string Name { get; set; }
    TeacherDeptDto TeacherDept { get; set;}
}