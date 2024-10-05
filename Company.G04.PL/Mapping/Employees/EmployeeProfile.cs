using AutoMapper;
using Company.G04.DAL.Model;
using Company.G04.PL.ViewModels.Employes;

namespace Company.G04.PL.Mapping.Employees
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            //CreateMap<EmployeeViewModel, Employee>();
            
        }
    }
}
