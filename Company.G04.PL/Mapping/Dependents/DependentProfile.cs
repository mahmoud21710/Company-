using AutoMapper;
using Company.G04.DAL.Model;
using Company.G04.PL.ViewModels.Dependents;

namespace Company.G04.PL.Mapping.Dependents
{
    public class DependentProfile : Profile
    {
        public DependentProfile()
        {
            CreateMap<Dependent,DependentViewModel>().ReverseMap();
        }
    }
}
