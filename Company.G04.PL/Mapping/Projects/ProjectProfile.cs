using AutoMapper;
using Company.G04.DAL.Model;
using Company.G04.PL.ViewModels.Projects;

namespace Company.G04.PL.Mapping.Projects
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project,ProjectViewModel>().ReverseMap();
        }
    }
}
