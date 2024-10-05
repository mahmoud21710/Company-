using AutoMapper;
using Company.G04.DAL.Model;
using Company.G04.PL.ViewModels.Departments;

namespace Company.G04.PL.Mapping.Departments
{
    public class DepartmentProfiler : Profile
    {
        public DepartmentProfiler()
        {
            CreateMap<Department,DepartmentViewModel>().ReverseMap();
        }
    }
}
